using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLNotes.Mapper;
using XMLNotes.Model;

namespace XMLNotes
{
    public class NoteService
    {
        private readonly IMapper<Note, NoteDto> _noteMapper = new NoteMapper();
        private readonly NoteRepository _repository;

        public NoteService(NoteRepository repository)
        {
            _repository = repository;
            _repository.Create();
        }

        public BindingList<NoteDto> GetAllNotes()
        {
            var notes = _repository.GetAll();
            var notesDto = new List<NoteDto>();
            foreach (var note in notes)
            {
                notesDto.Add(_noteMapper.ToDto(note));
            }
            return new BindingList<NoteDto>(notesDto);
        }

        public void Add(NoteDto noteDto)
        {
            var note = _noteMapper.ToEntity(noteDto);
            note.Id = Guid.NewGuid();
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
