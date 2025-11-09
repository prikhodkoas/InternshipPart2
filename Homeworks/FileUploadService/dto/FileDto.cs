namespace FileUploadService.dto
{
    /// <summary>
    /// Объект для передачи данных между сервисами 
    /// </summary>
    public class FileDto
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] Content { get; set; }
    }
}