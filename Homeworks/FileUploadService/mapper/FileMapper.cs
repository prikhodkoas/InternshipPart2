using DataBase.Model;
using FileUploadService.dto;
using System;

namespace FileUploadService.mapper
{
    /// <summary>
    /// Маппер между FileDto и File
    /// </summary>
    public class FileMapper : IMapper<FileDto, File>
    {
        public FileDto ToDto(File entity)
        {
            return new FileDto
            {
                FileName = entity.FileName,
                FilePath = entity.FilePath
            };
        }

        public File ToEntity(FileDto dto)
        {
            return new File
            {
                Id = new Guid(),
                FileName = dto.FileName,
                FilePath = dto.FilePath
            };
        }
    }
}
