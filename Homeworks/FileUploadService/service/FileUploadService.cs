using DataBase;
using FileUploadService.mapper;
using FileUploadService.dto;
using System.Runtime.InteropServices;


namespace FileUploadService.service
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IMapper<FileDto, DataBase.Model.File> _mapper = new FileMapper();

        private readonly string _connectionString;
        public FileUploadService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void UploadFile(FileDto fileDto)
        {
            using (var context = new AppDbContext(_connectionString))
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
