namespace FileUploadService.dto
{
    public class FileDto
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] Content { get; set; }
    }
}