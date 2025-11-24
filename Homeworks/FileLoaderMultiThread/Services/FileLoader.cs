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
                    throw new FileNotFoundException("Файл не найден: " + _file.FilePathFromSave);

                const int chunkSize = 8192;
                byte[] buffer = new byte[chunkSize];
                long totalRead = 0;
                long totalSize = new FileInfo(_file.FilePathFromSave).Length;

                int chunkNumber = 0;

                var fileDto = new FileDto
                {
                    FileName = _file.Name,
                    FilePath = _file.FilePathFromSave
                };

                var fileId = _fileUploadService.CreateFile(fileDto);

                using (var fs = new FileStream(_file.FilePathFromSave, FileMode.Open, FileAccess.Read))
                {
                    int bytesRead;
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        _pauseEvent.WaitOne();

                        _token.ThrowIfCancellationRequested();

                        byte[] chunkData = new byte[bytesRead];
                        Array.Copy(buffer, chunkData, bytesRead);

                        var chunkDto = new ChunkDto
                        {
                            FileId = fileId,
                            NumberInSequence = chunkNumber++,
                            Content = chunkData
                        };

                        _fileUploadService.UploadChunk(fileId, chunkDto, _token);

                        totalRead += bytesRead;
                        int percent = (int)((totalRead * 100) / totalSize);
                        ProgressChanged?.Invoke(percent);
                    }
                }
                _fileUploadService.CompleteFileUpload(fileId);
                _isLoaded = true;
                Completed?.Invoke();
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show($"Загрузка файла '{_file.FilePathFromSave}' отменена пользователем.");
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
