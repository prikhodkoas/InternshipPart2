using FileLoaderMultiThread.Services;

namespace FileLoaderMultiThread
{

    public static class FileLoaderServiceFactory
    {
        
        public static IFileLoaderService Create() => new FileLoaderService(new FileUploadService.service.FileUploadService("Server=localhost;Database=FileStorageDb;Trusted_Connection=True;"));
    }
}
