using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLNotes.Model;

namespace XMLNotes
{
    public partial class NotesForm : Form
    {
        private readonly NoteService _noteService;
        private readonly Dictionary<Guid, NoteCard> _cards = new Dictionary<Guid, NoteCard>();

        public NotesForm()
        {
            InitializeComponent();

            // Создаём сервис
            string filePath = Path.Combine(Application.StartupPath, "notes.xml");
            _noteService = new NoteService(new NoteRepository(filePath));
            LoadAllNotes();
        }

        private void LoadAllNotes()
        {
            flowLayoutPanelNotes.Controls.Clear();
            _cards.Clear();

            var notes = _noteService.GetAllNotes();
            foreach (var note in notes)
            {
                AddCardToUI(note);
            }
        }

        private void AddCardToUI(Note note)
        {
            var card = new NoteCard();

            card.TitleTextBox.Text = note.Title;
            card.TextRichTextBox.Text = note.Text;
            card.CreatedAtDateTimePicker.Value = note.CreatedAt;

            card.Click += Card_Click;

            flowLayoutPanelNotes.Controls.Add(card);
            _cards[note.Id] = card;
        }


        public void LoadFromNote(NoteCard card, Note note)
        {
            card.TitleTextBox.Text = note.Title;
            card.TextRichTextBox.Text = note.Text;
            card.CreatedAtDateTimePicker.Value = note.CreatedAt;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var note = new Note
            {
                Title = "Новая заметка",
                Text = "",
                CreatedAt = DateTime.Now
            };

            _noteService.Add(note);
            AddCardToUI(note);
        }
    }
}
