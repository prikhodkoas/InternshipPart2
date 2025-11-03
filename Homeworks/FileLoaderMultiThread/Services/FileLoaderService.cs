using FileLoaderMultiThread.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileLoaderMultiThread.Services
{
    /// <summary>
    /// Сервис по загрузке файлов 
    /// </summary>
    internal class FileLoaderService : IFileLoaderService
    {
        /// <summary>
        /// Загрузчики файлов (каждый загрузчик работает в своем потоке)
        /// </summary>
        private readonly Dictionary<Guid, FileLoader> _downloaders = new Dictionary<Guid, FileLoader>();
        /// <summary>
        /// Токены для отмены загрузчиков
        /// </summary>
        private readonly Dictionary<Guid, CancellationTokenSource> _tokens = new Dictionary<Guid, CancellationTokenSource>();

        /// <summary>
        /// Событие об изменении прогресса загрузки
        /// </summary>
        public event Action<Guid, int> ProgressChanged;
        
        /// <summary>
        /// Событие о завершении загрузки файлов
        /// </summary>
        public event Action<Guid> Completed;

        /// <summary>
        /// Создает загрузчик файла 
        /// </summary>
        /// <param name="file">Информация о файле</param>
        public void LoadFile(DownloadFile file)
        {
            if (_downloaders.ContainsKey(file.Id)) return;

            var cts = new CancellationTokenSource();
            _tokens[file.Id] = cts;

            var loader = new FileLoader(file, cts.Token);
            loader.ProgressChanged += percent => ProgressChanged?.Invoke(file.Id, percent);
            loader.Completed += () => Completed?.Invoke(file.Id);

            _downloaders[file.Id] = loader;
            loader.Start();
        }

        /// <summary>
        /// Останавливает загрузчик файлов
        /// </summary>
        /// <param name="fileId">id загрузчика</param>
        public void PauseLoadFile(Guid fileId)
        {
            if (_downloaders.TryGetValue(fileId, out var loader))
                loader.Pause();
        }

        /// <summary>
        /// Возобновляет загрузчик файлов
        /// </summary>
        /// <param name="fileId">id загрузчика</param>
        public void ResumeLoadFile(Guid fileId)
        {
            if (_downloaders.TryGetValue(fileId, out var loader))
                loader.Resume();
        }

        /// <summary>
        /// Отменяет загрузку файла загрузчиком
        /// </summary>
        /// <param name="fileId">id загрузчика</param>
        public void CancelLoadFile(Guid fileId)
        {
            if (_tokens.TryGetValue(fileId, out var cts))
            {
                cts.Cancel();
                _downloaders.Remove(fileId);
                _tokens.Remove(fileId);
            }
        }

        /// <summary>
        /// Определяет, загружен ли файл
        /// </summary>
        /// <param name="fileId">id загрузчика</param>
        /// <returns>Загружен ли файл</returns>
        public bool IsLoaded(Guid fileId)
        {
            return _downloaders.TryGetValue(fileId, out var loader) && loader.IsLoaded();
        }
    }
}

