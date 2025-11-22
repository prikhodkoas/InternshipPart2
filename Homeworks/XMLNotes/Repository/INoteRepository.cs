using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLNotes.Model;

namespace XMLNotes.Repository
{
    /// <summary>
    /// Интерфейс для работы с заметками 
    /// </summary>
    public interface INoteRepository
    {
        bool Create();
        List<Note> GetAll();
        void Add(Note note);
        void Delete(Guid id);
        void Update(Note updated);
        bool ChangeFilePath(string newPath);
    }
}
