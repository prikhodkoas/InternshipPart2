using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLNotes.Model;

namespace XMLNotes
{
    public partial class NoteCard : UserControl
    {
        public Guid Id { get; private set; }
        public NoteCard()
        {
            InitializeComponent();
        }

        // Загружаем данные заметки в контрол
        public void LoadFromNote(Note note)
        {
            Id = note.Id;

            TitleTextBox.Text = note.Title;
            TextRichTextBox.Text = note.Text;
            CreatedAtLbl.Text += " " + note.CreatedAt.ToString("dd.MM.yyyy HH:mm");
        }

        // Создаём заметку из UI-контрола
        public Note ToNote()
        {
            return new Note
            {
                Id = Id,
                Title = TitleTextBox.Text,
                Text = TextRichTextBox.Text,
                CreatedAt = DateTime.Parse(CreatedAtLabel.Text)
            };
        }
    }
}
