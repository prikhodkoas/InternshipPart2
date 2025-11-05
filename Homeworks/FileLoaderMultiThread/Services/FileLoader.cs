using FileLoaderMultiThread.Model;
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
        private readonly DownloadFile _file;

        /// <summary>
        /// Токен отмены
        /// </summary>
        private readonly CancellationToken _token;

        /// <summary>
        /// Синзронизатор для работы с файлом
        /// </summary>
        private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);

        /// <summary>
        /// Имя файла
        /// </summary>
        private string fileName;

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

        public FileLoader(DownloadFile file, CancellationToken cancellationToken)
        {
            _file = file;
            _token = cancellationToken;
        }

        /// <summary>
        /// Запускает загрузку файла в новом потоке
        /// </summary>
        public void Start()
        {
            var thread = new Thread(Download);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// Загрузжает файл из сети
        /// </summary>
        private void Download()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_file.Url);
                //for debug
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
                request.Accept = "*/*";
                request.Referer = _file.Url;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    string contentDisposition = response.Headers["Content-Disposition"];
                    string fileName = null;
                    
                    if (string.IsNullOrEmpty(fileName))
                        fileName = Path.GetFileName(new Uri(_file.Url).AbsolutePath);

                    _file.Name = fileName;

                    using (var stream = response.GetResponseStream())
                    {
                        using (var fs = new FileStream(_file.FilePathToSave, FileMode.Create, FileAccess.Write))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;
                            long totalRead = 0;
                            long totalSize = response.ContentLength;

                            // 🛡️ Защита от некорректного ContentLength
                            bool hasValidSize = totalSize > 0;

                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                _pauseEvent.WaitOne();
                                if (_token.IsCancellationRequested) return;

                                fs.Write(buffer, 0, bytesRead);
                                totalRead += bytesRead;

                                if (hasValidSize)
                                {
                                    int percent = (int)((totalRead * 100) / totalSize);
                                    percent = Math.Max(0, Math.Min(100, percent)); // Защита от выхода за границы
                                    ProgressChanged?.Invoke(percent);
                                }
                            }

                            if (!hasValidSize)
                                ProgressChanged?.Invoke(100); // Если размер неизвестен — просто 100% в конце

                            _isLoaded = true;
                            Completed?.Invoke();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
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

        public DownloadFile GetDownloadFile()
        {
            return _file;
        }
    }


}
