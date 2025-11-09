using FileLoaderMultiThread.Model;
using FileUploadService;
using FileUploadService.dto;
using FileUploadService.service;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace FileLoaderMultiThread
{
    /// <summary>
    /// Загрузчик файлов
    /// </summary>
    public class FileLoader
    {
        /// <summary>
        /// Информация о загружаемом файле
        /// </summary>
        private readonly UploadFile _file;

        /// <summary>
        /// Токен отмены
        /// </summary>
        private readonly CancellationToken _token;

        /// <summary>
        /// Синзронизатор для работы с файлом
        /// </summary>
        private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);

        /// <summary>
        /// Сервис для сохранения файла в БД
        /// </summary>
        private readonly IFileUploadService _fileUploadService;

        /// <summary>
        /// Загружен ли файл
        /// </summary>
        private bool _isLoaded = false;

        /// <summary>
        /// Событие об изменении прогресса загрузки
        /// </summary>
        public event Action<int> ProgressChanged;

        /// <summary>
        /// Событие о завершении загрузки файлов
        /// </summary>
        public event Action Completed;

        public FileLoader(UploadFile file, CancellationToken cancellationToken, IFileUploadService fileUploadService)
        {
            _file = file;
            _token = cancellationToken;
            _fileUploadService = fileUploadService;
        }

        /// <summary>
        /// Запускает загрузку файла в новом потоке
        /// </summary>
        public void Start()
        {
            var thread = new Thread(LoadFromFileSystem);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// Загрузжает файл из файловой системы
        /// </summary>
        private void LoadFromFileSystem()
        {
            try
            {
                if (!File.Exists(_file.FilePathFromSave))
                {
                    throw new FileNotFoundException("Файл не найден: " + _file.FilePathFromSave);
                }

                FileInfo fileInfo = new FileInfo(_file.FilePathFromSave);
                long totalSize = fileInfo.Length;
                long totalRead = 0;

                byte[] buffer = new byte[8192];

                using (var fs = new FileStream(_file.FilePathFromSave, FileMode.Open, FileAccess.Read))
                using (var ms = new MemoryStream())
                {
                    int bytesRead;
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        _pauseEvent.WaitOne();
                        
                        if (_token.IsCancellationRequested)
                            return;

                        ms.Write(buffer, 0, bytesRead);
                        totalRead += bytesRead;

                        int percent = (int)((totalRead * 100) / totalSize);
                        ProgressChanged?.Invoke(percent);
                    }

                    // Сохраняем в БД
                    var dto = new FileDto
                    {
                        FileName = _file.Name,
                        FilePath = _file.FilePathFromSave,
                        Content = ms.ToArray()
                    };

                    _fileUploadService.UploadFile(dto);
                }

                _isLoaded = true;
                Completed?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки файла '{_file.FilePathFromSave}': {ex.Message}");
            }
        }


        /// <summary>
        /// Останавливает загрузку файла
        /// </summary>
        public void Pause() => _pauseEvent.Reset();

        /// <summary>
        /// Возобновляет загрузку файла
        /// </summary>
        public void Resume() => _pauseEvent.Set();

        /// <summary>
        /// Опредеделяет, загружен ли файл
        /// </summary>
        /// <returns>Загружен ли файл</returns>
        public bool IsLoaded() => _isLoaded;

        public UploadFile GetUploadFile()
        {
            return _file;
        }
    }
}
