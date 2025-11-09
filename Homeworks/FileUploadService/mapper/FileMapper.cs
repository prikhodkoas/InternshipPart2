using FileUploadService.dto;

namespace FileUploadService.mapper
{
    public class FileMapper : IMapper<FileDto, DataBase.Model.File>
    {
        public FileDto ToDto(DataBase.Model.File entity)
        {
            return new FileDto
            {
                FileName = entity.FileName,
                FilePath = entity.FilePath,
                Content = entity.Content
            };
        }

        public DataBase.Model.File ToEntity(FileDto dto)
        {
            return new DataBase.Model.File
            {
                FileName = dto.FileName,
                FilePath = dto.FilePath,
                Content = dto.Content
            };
        }
    }
}
