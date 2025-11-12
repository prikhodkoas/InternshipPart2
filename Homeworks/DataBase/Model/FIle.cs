using System;

namespace DataBase.Model
{
    /// <summary>
    /// Сущность Файл
    /// </summary>
    public class File
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
