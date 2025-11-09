using FileUploadService.dto;

namespace FileUploadService.service
{
    public interface IFileUploadService
    {
        void UploadFile(FileDto fileDto);
    }
}
