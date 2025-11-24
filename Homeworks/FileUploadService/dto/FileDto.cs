namespace FileUploadService.dto
{
    /// <summary>
    /// Объект для передачи FIle между сервисами 
    /// </summary>
    public class FileDto
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}