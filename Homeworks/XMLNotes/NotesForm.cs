using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using XMLNotes.Model;

namespace XMLNotes
{
    public partial class NotesForm : Form
    {
        private readonly NoteService _noteService;
        private BindingList<NoteDto> _notes = new BindingList<NoteDto>(); 

        public NotesForm()
        {
            InitializeComponent();
            
            NotesGridView.DataSource = _notes;
            NotesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NotesGridView.RowHeaderMouseClick += NotesGridView_RowHeaderMouseClick;
            NotesGridView.CellClick += NotesGridView_CellClick;


            // Создаём сервис
            string filePath = Path.Combine(Application.StartupPath, "notes.xml");
            _noteService = new NoteService(new NoteRepository(filePath));
            LoadAllNotes();
        }

        /// <summary>
        /// Обработчик для выделения всей строки
        /// </summary>
        private void NotesGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            NotesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            NotesGridView.ClearSelection();
            NotesGridView.Rows[e.RowIndex].Selected = true;
        }

        /// <summary>
        /// Обработчик для выделения отдельной ячейки
        /// </summary>
        private void NotesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                NotesGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                NotesGridView.ClearSelection();
                NotesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
        }

        private void LoadAllNotes()
        {
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
