using DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBase.Repository
{
    /// <summary>
    /// Репозиторий для работы с таблицей Файл в БД
    /// </summary>
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext _appDbContext;
        public FileRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public Guid AddFile(File file) 
        {
            _appDbContext.Files
            .Add(file);
            return file.Id;
        }

        public void Save() => _appDbContext.SaveChanges();
        
        public void AddChunk(Chunk chunk) => _appDbContext.Chunks
            .Add(chunk);

        public List<Chunk> GetChunks(Guid fileId) => _appDbContext.Chunks
            .Where(fd => fd.FileId == fileId)
            .OrderBy(fd => fd.NumberInSequence)
            .ToList();
    }
}
