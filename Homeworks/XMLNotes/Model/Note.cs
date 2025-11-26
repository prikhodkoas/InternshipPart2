using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLNotes.Model
{
    /// <summary>
    /// Модель заметки
    /// </summary>
    public class Note
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public override bool Equals(object obj)
        {
            if(obj is Note note)
                return this.Id == note.Id;
            return false;
        }
    }
}
