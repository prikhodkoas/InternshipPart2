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
        void LoadFile(DownloadFile downloadFile);
        void PauseLoadFile(Guid fileId);
        void ResumeLoadFile(Guid fileId);
        void CancelLoadFile(Guid fileId);
        bool IsLoaded(Guid fileId);
    }
}
