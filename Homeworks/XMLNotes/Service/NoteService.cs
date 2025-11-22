using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLNotes.Mapper;
using XMLNotes.Model;
using XMLNotes.Repository;

namespace XMLNotes
{
    /// <summary>
    /// Сервис по работе с заметками
    /// </summary>
    public class NoteService
    {
        /// <summary>
        /// Маппер UI-модели данных заметок с моделью данных заметок XML
        /// </summary>
        private readonly IMapper<Note, NoteDto> _noteMapper = new NoteMapper();
        
        /// <summary>
        /// Репозиторий для сохранения заметок 
        /// </summary>
        private readonly INoteRepository _repository;

        public NoteService(INoteRepository repository)
        {
            _repository = repository;
            _repository.Create();
        }

        /// <summary>
        /// Получение всех заметок из репозитория
        /// </summary>
        /// <returns>Список заметок</returns>
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

        /// <summary>
        /// Добавление заметки
        /// </summary>
        /// <param name="noteDto">UI-модель заметки</param>
        public void Add(NoteDto noteDto)
        {
            var note = _noteMapper.ToEntity(noteDto);
            note.Id = Guid.NewGuid();
            _repository.Add(note);
        }

        /// <summary>
        /// Обновление заметки
        /// </summary>
        /// <param name="noteDto">UI-модель заметки</param>
        public void Update(NoteDto noteDto)
        {
            var note = _noteMapper.ToEntity(noteDto);
            if(Guid.TryParse(noteDto.Id, out Guid result))
                note.Id = result;
            _repository.Update(note);
        }

        /// <summary>
        /// Удаление заметки
        /// </summary>
        /// <param name="id">ID UI-модели заметки</param>
        public void Delete(string id)
        {
            if(Guid.TryParse(id, out Guid result))
            {
                _repository.Delete(result);
            }
        }

        /// <summary>
        /// Открытие файла с заметками
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        /// <exception cref="FormatException">Файл не соответствует рабочему формату</exception>
        public BindingList<NoteDto> OpenNotesFromFile(string filePath)
        {
            try
            {
                if (!_repository.ChangeFilePath(filePath))
                {
                    throw new InvalidOperationException("Не удалось открыть файл заметок: путь некорректен.");
                }
                return GetAllNotes();
            }
            catch
            {
                throw new FormatException("Не удалось открыть файл заметок: файл не соответствует структуре!");
            }
        }
    }
}
