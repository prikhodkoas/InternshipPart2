using DataBase;
using FileLoaderMultiThread.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadService
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IMapper<FileDto, DataBase.Model.File> _mapper;

        public FileUploadService(IMapper<FileDto, DataBase.Model.File> mapper)
        {
            _mapper = mapper;
        }

        public void UploadFile(FileDto fileDto)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var entity = _mapper.ToEntity(fileDto);
                        context.Files.Add(entity);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
