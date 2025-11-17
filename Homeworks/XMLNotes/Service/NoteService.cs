using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLNotes.Model;

namespace XMLNotes
{
    public class NoteService
    {
        private readonly NoteRepository _repository;

        public NoteService(NoteRepository repository)
        {
            _repository = repository;
            _repository.Create();
        }

        public List<Note> GetAllNotes()
        {
            return _repository.GetAll();
        }

        public void Add(Note note)
        {
            _repository.Add(note);
        }

        public void Update(Note note)
        {
            _repository.Update(note);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
