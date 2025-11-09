using FileLoaderMultiThread.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileLoaderMultiThread.Services
{
    /// <summary>
    /// Интерфейс сервиса по загрузке файлов
    /// </summary>
    public interface IFileLoaderService
    {
        /// <summary>
        /// Событие об изменении прогресса загрузки
        /// </summary>
        event Action<Guid, int> ProgressChanged;

        /// <summary>
        /// Событие о завершении загрузки файлов
        /// </summary>
        event Action<Guid> Completed;
        void LoadFile(UploadFile downloadFile);
        void PauseLoadFile(Guid fileId);
        void ResumeLoadFile(Guid fileId);
        void CancelLoadFile(Guid fileId);
        bool IsLoaded(Guid fileId);
        FileLoader GetFileLoader(Guid fileId);
    }
}
