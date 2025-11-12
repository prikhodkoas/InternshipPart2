using DataBase;
using DataBase.Model;
using FileUploadService.dto;
using FileUploadService.mapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileUploadService.service
{
    /// <summary>
    /// Сессия загрузки файла в БД
    /// </summary>
    public class FileUploadSession : IDisposable
    {

        private readonly IMapper<FileDto, File> _fileMapper = new FileMapper();

        private readonly IMapper<ChunkDto, Chunk> _chunkMapper = new ChunkMapper();

        private readonly AppDbContext _context;
        private readonly DbContextTransaction _transaction;

        private bool _committed = false;

        public FileUploadSession(string connectionString)
        {
            _context = new AppDbContext(connectionString);
            _transaction = _context.Database.BeginTransaction();
        }

        /// <summary>
        /// Создаёт запись о файле и возвращает его Id
        /// </summary>
        public Guid CreateFile(FileDto fileDto)
        {
            var fileEntity = _fileMapper.ToEntity(fileDto);

            fileEntity.Id = Guid.NewGuid();

            _context.Files.Add(fileEntity);

            return fileEntity.Id;
        }

        /// <summary>
        /// Добавляет один чанк к файлу
        /// </summary>
        public void UploadChunk(ChunkDto chunkDto, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var chunk = _chunkMapper.ToEntity(chunkDto);
            _context.Chunks.Add(chunk);
            _context.SaveChanges();
        }

        /// <summary>
        /// Подтверждает запись всех файлов
        /// </summary>
        public void Commit()
        {
            _transaction.Commit();
            _committed = true;
        }

        public void Dispose()
        {
            if (!_committed)
                _transaction.Rollback();

            _transaction.Dispose();
            _context.Dispose();
        }
    }
}
