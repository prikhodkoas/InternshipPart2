using FileLoaderMultiThread.Services;

namespace FileLoaderMultiThread
{
    /// <summary>
    /// Класс для конфигурации приложения
    /// </summary>
    public static class FileLoaderServiceFactory
    {
        public static IFileLoaderService Create() => new FileLoaderService(new FileUploadService.service.FileUploadService(@"Server=IM1834\SQLEXPRESS;Database=FileStorageDb;Trusted_Connection=True;TrustServerCertificate=True;"));
    }
}
