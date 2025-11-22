using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using XMLNotes.Model;

namespace XMLNotes
{
    public partial class NotesForm : Form
    {
        private NoteCard NoteCard { get; set; }
        private Button ApplyBtn {  get; set; }

        private readonly NoteService _noteService;
  
        private BindingList<NoteDto> _notes = new BindingList<NoteDto>(); 

        public NotesForm()
        {
            InitializeComponent();

            NoteCard = CreateCard();

            ApplyBtn = CreateButton();
            this.Controls.Add(ApplyBtn);

            NotesGridView.DataSource = _notes;
            NotesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NotesGridView.AllowUserToAddRows = false;
            NotesGridView.ReadOnly = true;

            NotesGridView.RowHeaderMouseClick += NotesGridView_RowHeaderMouseClick;
            NotesGridView.CellClick += NotesGridView_CellClick;

            // Сервис
            string filePath = Path.Combine(Application.StartupPath, "notes.xml");
            _noteService = new NoteService(new NoteRepository(filePath));
            LoadAllNotes();
        }

        /// <summary>
        /// Создание динамически карточки заметки на форме
        /// </summary>
        /// <returns>Карточка заметки</returns>
        private NoteCard CreateCard()
        {
            var noteCard = new NoteCard();
            noteCard.Parent = this;
            noteCard.Location = new Point(this.NotesGridView.Width + 8,
                this.deleteBtn.Location.Y + this.deleteBtn.Height + 8);
            noteCard.Size = new Size(addBtn.Width + editBtn.Width + 8, 200);
            noteCard.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            noteCard.Visible = false;
            return noteCard;
        }


        /// <summary>
        /// Создание динамически кнопки подтверждения на форме
        /// </summary>
        /// <returns>Карточка заметки</returns>
        private Button CreateButton()
        {
            var btn = new Button();
            btn.Size = new Size(180, 35);
            btn.Location = new Point(this.Width - 8 - btn.Size.Width,
                this.NotesGridView.Location.Y + this.NotesGridView.Height + 8);
            btn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btn.Text = "Подтвердить";
            btn.Click += Btn_Click;
            btn.Visible = false;
            return btn;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            
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

        /// <summary>
        /// Загрузка заметок в таблицу с заметками
        /// </summary>
        private void LoadAllNotes()
        {
            _notes = _noteService.GetAllNotes();
            NotesGridView.DataSource = _notes;
        }

        /// <summary>
        /// Инициализация полей в карточке
        /// </summary>
        private void InitializeCard()
        {
            NoteCard.TitleTextBox.Text = "Новая заметка";
            NoteCard.TextRichTextBox.Text = "";
            NoteCard.CreatedAtDateTimePicker.Value = DateTime.Now;
        }

        private void AddCardToUI(Note note)
        {
            var card = new NoteCard();

            card.TitleTextBox.Text = note.Title;
            card.TextRichTextBox.Text = note.Text;
            card.CreatedAtDateTimePicker.Value = note.CreatedAt;

        }


        public void LoadFromNote(NoteCard card, Note note)
        {
            card.TitleTextBox.Text = note.Title;
            card.TextRichTextBox.Text = note.Text;
            card.CreatedAtDateTimePicker.Value = note.CreatedAt;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            NoteCard.Visible = true;
            InitializeCard();

            NoteCard.Focus();
            NoteCard.TitleTextBox.Focus();
            NoteCard.TitleTextBox.SelectAll();

            ApplyBtn.Visible = true;
            // 
            //var note = new Note
            //{
            //    Title = "Новая заметка",
            //    Text = "",
            //    CreatedAt = DateTime.Now
            //};

            //_noteService.Add(note);
            //AddCardToUI(note);
        }
    }
}
