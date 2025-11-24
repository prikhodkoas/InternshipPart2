using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    /// <summary>
    /// Сущность блока данных
    /// </summary>
    public class Chunk
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FileId { get; set; } 
        public int NumberInSequence { get; set; }
        public byte[] Content { get; set; }
    }
}
