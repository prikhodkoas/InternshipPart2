using DataBase;
using DataBase.Model;
using FileUploadService.dto;
using FileUploadService.mapper;
using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using System.Threading;


namespace FileUploadService.service
{
    /// <summary>
    /// Сервис для записи файла в БД
    /// </summary>
    public class FileUploadService : IFileUploadService
    {
        private readonly string _connectionString;

        // Сессии храним по fileId
        private readonly ConcurrentDictionary<Guid, FileUploadSession> _sessions = new ConcurrentDictionary<Guid, FileUploadSession>();

        public FileUploadService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Создаёт запись о файле и возвращает его Id
        /// </summary>
        public Guid CreateFile(FileDto fileDto)
        {
            var session = new FileUploadSession(_connectionString);
            var fileId = session.CreateFile(fileDto);

            _sessions[fileId] = session;

            return fileId;
        }

        /// <summary>
        /// Загружает один чанк в файл
        /// </summary>
        public void UploadChunk(Guid fileId, ChunkDto chunkDto, CancellationToken token)
        {
            if (!_sessions.TryGetValue(fileId, out var session))
                throw new InvalidOperationException("Сессия для этого файла не найдена");

            session.UploadChunk(chunkDto, token);
        }

        /// <summary>
        /// Завершает загрузку файла (коммит транзакции)
        /// </summary>
        public void CompleteFileUpload(Guid fileId)
        {
            if (!_sessions.TryRemove(fileId, out var session))
                throw new InvalidOperationException("Сессия для этого файла не найдена");

            session.Commit();
            session.Dispose();
        }

        /// <summary>
        /// Отменяет загрузку файла (rollback)
        /// </summary>
        public void CancelFileUpload(Guid fileId)
        {
            if (_sessions.TryRemove(fileId, out var session))
            {
                session.Dispose(); // Rollback произойдет автоматически
            }
        }
    }
}
