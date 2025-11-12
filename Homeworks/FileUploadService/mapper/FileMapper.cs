using FileUploadService.dto;
using System;

namespace FileUploadService.mapper
{
    /// <summary>
    /// Маппер для записи в БД
    /// </summary>
    public class FileMapper : IMapper<FileDto, DataBase.Model.File>
    {
        public FileDto ToDto(DataBase.Model.File entity)
        {
            return new FileDto
            {
                FileName = entity.FileName,
                FilePath = entity.FilePath
            };
        }

        public DataBase.Model.File ToEntity(FileDto dto)
        {
            return new DataBase.Model.File
            {
                Id = new Guid(),
                FileName = dto.FileName,
                FilePath = dto.FilePath
            };
        }
    }
}
