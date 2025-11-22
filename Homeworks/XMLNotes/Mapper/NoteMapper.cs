using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLNotes.Model;

namespace XMLNotes.Mapper
{
    /// <summary>
    /// Маппер UI-модели данных заметок с моделью данных заметок XML
    /// </summary>
    internal class NoteMapper : IMapper<Note, NoteDto>
    {
        public NoteDto ToDto(Note entity)
        {
            return new NoteDto
            {
                Id = entity.Id.ToString(),
                Title = entity.Title,
                Description = entity.Text,
                UpdatedAt = entity.CreatedAt
            };
        }

        public Note ToEntity(NoteDto dto)
        {
            return new Note
            {
                Title = dto.Title,
                Text = dto.Description,
                CreatedAt = dto.UpdatedAt
            };
        }
    }
}
