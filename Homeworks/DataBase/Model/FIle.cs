using System;

namespace DataBase.Model
{
    public class File
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
