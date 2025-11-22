using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XMLNotes.Repository;

namespace XMLNotes
{
    /// <summary>
    /// Форма для работы с заметками
    /// </summary>
    public partial class NotesForm : Form
    {
        /// <summary>
        /// Контрол для взаимодействия с заметкой
        /// </summary>
        private NoteCard NoteCard { get; set; }

        /// <summary>
        /// Кнопка подтверждения действия
        /// </summary>
        private Button ApplyBtn { get; set; }

        /// <summary>
        /// Кнопка отмены действия
        /// </summary>
        private Button CancelButton { get; set; }

        /// <summary>
        /// Сервис по работе с заметками
        /// </summary>
        private readonly NoteService _noteService;

        /// <summary>
        /// Структура для биндинга данных на таблицу
        /// </summary>
        private BindingList<NoteDto> _notes = new BindingList<NoteDto>();

        /// <summary>
        /// Текущая рабочая заметка
        /// </summary>
        private NoteDto CurrentNote { get; set; }

        /// <summary>
        /// Режим работы кнопки подтверждения действия
        /// </summary>
        private ActionMode _actionMode = ActionMode.Add;

        public NotesForm()
        {
            InitializeComponent();

            NoteCard = CreateCard();
            this.Controls.Add(NoteCard);
            ApplyBtn = CreateApplyButton();
            this.Controls.Add(ApplyBtn);
            CancelButton = CreateCancelButton();
            this.Controls.Add(CancelButton);

            NotesGridView.DataSource = _notes;
            NotesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NotesGridView.AllowUserToAddRows = false;
            NotesGridView.ReadOnly = true;

            NotesGridView.RowHeaderMouseClick += NotesGridView_RowHeaderMouseClick;
            NotesGridView.CellClick += NotesGridView_CellClick;

            // Сервис
            string filePath = Path.Combine(Application.StartupPath, "notes.xml");
            _noteService = new NoteService(new XMLNoteRepository(filePath));
            LoadAllNotes();
        }

        /// <summary>
        /// Загрузка заметок в таблицу с заметками
        /// </summary>
        private void LoadAllNotes()
        {
            _notes = _noteService.GetAllNotes();
            NotesGridView.DataSource = _notes;
        }

        #region Инициализация динамически создаваемых элементов

        /// <summary>
        /// Создание карточки заметки на форме
        /// </summary>
        /// <returns>Карточка заметки</returns>
        private NoteCard CreateCard()
        {
            var noteCard = new NoteCard();
            noteCard.Parent = this;
            noteCard.Location = new Point(this.NotesGridView.Width + 8,
                this.deleteBtn.Location.Y + this.deleteBtn.Height + 8);
            noteCard.Size = new Size(addBtn.Width + editBtn.Width + 8, 210);
            noteCard.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            noteCard.Visible = false;
            return noteCard;
        }

        /// <summary>
        /// Создание кнопки подтверждения на форме
        /// </summary>
        /// <returns>Карточка заметки</returns>
        private Button CreateApplyButton()
        {
            var btn = new Button();
            btn.Size = new Size(120, 25);
            btn.Location = new Point(ClientSize.Width - 16 - btn.Size.Width,
                this.NoteCard.Location.Y + this.NoteCard.Height + 8);
            btn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btn.Text = "Подтвердить";
            btn.Click += ApplyBtn_Click;
            btn.Visible = false;
            return btn;
        }

        /// <summary>
        /// Создание кнопки отмены на форме
        /// </summary>
        /// <returns>Карточка заметки</returns>
        private Button CreateCancelButton()
        {
            var btn = new Button();
            btn.Size = new Size(120, 25);
            btn.Location = new Point(ApplyBtn.Left - btn.Width - 8,
                NoteCard.Bottom + 8);
            btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn.Text = "Отмена";
            btn.Click += CancelBtn_Click;
            btn.Visible = false;
            return btn;
        }

        #endregion

        /// <summary>
        /// Обработчик нажатия на кнопку подтверждения действия с заметкой
        /// </summary>
        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            switch (_actionMode)
            {
                case ActionMode.Add:
                    {
                        HideControls();

                        var noteDto = new NoteDto()
                        {
                            Title = NoteCard?.TitleTextBox?.Text,
                            Description = NoteCard?.TextRichTextBox?.Text,
                            UpdatedAt = NoteCard.CreatedAtDateTimePicker.Value
                        };
                        _notes.Add(noteDto);

                        _noteService.Add(noteDto);
                    }
                    break;
                case ActionMode.Edit:
                    {
                        HideControls();

                        var noteDto = _notes.FirstOrDefault(n => n.Id == CurrentNote.Id);
                        if (noteDto != null)
                        {
                            noteDto.Title = NoteCard.TitleTextBox.Text;
                            noteDto.Description = NoteCard.TextRichTextBox.Text;
                            noteDto.UpdatedAt = NoteCard.CreatedAtDateTimePicker.Value;
                        }

                        _noteService.Update(noteDto);
                    }
                    break;
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку отмены дйствия с заметкой
        /// </summary>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            InitializeCard();
            HideControls();
        }
        
        /// <summary>
        /// Скрытие всех контролов для создания заметки
        /// </summary>
        private void HideControls()
        {
            NoteCard.Visible = false;
            ApplyBtn.Visible = false;
            CancelButton.Visible = false;
        }

        /// <summary>
        /// Показ контролов для создания заметки
        /// </summary>
        private void ShowControls()
        {
            NoteCard.Visible = true;
            ApplyBtn.Visible = true;
            CancelButton.Visible = true;
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
        /// Инициализация полей в карточке
        /// </summary>
        private void InitializeCard()
        {
            NoteCard.TitleTextBox.Text = "Новая заметка";
            NoteCard.TextRichTextBox.Text = "";
            NoteCard.CreatedAtDateTimePicker.Value = DateTime.Now;
        }

        /// <summary>
        /// Обработчик кнопки Добавление заметки
        /// </summary>
        private void addBtn_Click(object sender, EventArgs e)
        {
            InitializeCard();
            ShowControls();

            NoteCard.Focus();
            NoteCard.TitleTextBox.Focus();
            NoteCard.TitleTextBox.SelectAll();
            _actionMode = ActionMode.Add;
        }

        /// <summary>
        /// Обработчик кнопки Редактирование заметки
        /// </summary>
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (NotesGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выделите строку для редактирования заметки!", "Ошибка");
                return;
            }
            if (NotesGridView.SelectedRows[0].DataBoundItem is NoteDto noteDto)
            {
                LoadFromNote(noteDto);
                ShowControls();
                CurrentNote = noteDto;
                _actionMode = ActionMode.Edit;
            }
        }

        /// <summary>
        /// Инициализация карточки заметки для редактирования
        /// </summary>
        public void LoadFromNote(NoteDto noteDto)
        {
            NoteCard.TitleTextBox.Text = noteDto.Title;
            NoteCard.TextRichTextBox.Text = noteDto.Description;
            NoteCard.CreatedAtDateTimePicker.Value = noteDto.UpdatedAt;
        }

        /// <summary>
        /// Обработчик кнопки Удаление заметки
        /// </summary>
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (NotesGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выделите строку для удаления заметки!", "Ошибка");
                return;
            }
            var result = MessageBox.Show(
                        "Вы уверены, что хотите удалить выбранную заметку?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (NotesGridView.SelectedRows[0].DataBoundItem is NoteDto noteDto)
                {
                    _notes.Remove(noteDto);
                    _noteService.Delete(noteDto.Id);
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки Открытие нового файла с заметками
        /// </summary>
        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenNotesFileDialog.Filter = "XML файлы (*.xml)|*.xml";
            OpenNotesFileDialog.Title = "Выберите файл заметок";
            if (OpenNotesFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _notes = _noteService.OpenNotesFromFile(OpenNotesFileDialog.FileName);

                    NotesGridView.DataSource = _notes;

                    MessageBox.Show("Файл успешно открыт!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка открытия файла: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Поиск по ключевым словам
        /// </summary>
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchInGrid(SearchTextBox.Text);
        }

        /// <summary>
        /// Выделение заметок которые совпадают по ключевому слову
        /// </summary>
        /// <param name="keyword"></param>
        private void SearchInGrid(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return;

            foreach (DataGridViewRow row in NotesGridView.Rows)
            {
                row.Selected = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null &&
                        cell.Value.ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }
        
        /// <summary>
        /// Обработчик события потери фокуса textbox'а для поиска 
        /// </summary>
        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            SearchTextBox.Text = string.Empty;
        }
    }
}
