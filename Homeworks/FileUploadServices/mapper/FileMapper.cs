using System;
using DataBase.Model;

namespace FileUploadService
{
    public class FileMapper : IMapper<FileDto, File>
    {
        public FileDto ToDto(File entity)
        {
            throw new NotImplementedException();
        }

        public File ToEntity(FileDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
