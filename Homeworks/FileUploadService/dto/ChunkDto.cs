using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadService.dto
{
    /// <summary>
    /// Класс для передачи Chunk между сервисами
    /// </summary>
    public class ChunkDto
    {
        public Guid FileId { get; set; }
        public int NumberInSequence { get; set; }
        public byte[] Content { get; set; }
    }
}
