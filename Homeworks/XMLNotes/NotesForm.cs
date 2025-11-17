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
        private readonly NoteService _service;
        private readonly Dictionary<Guid, NoteCard> _cards = new Dictionary<Guid, NoteCard>();

        public NotesForm()
        {
            InitializeComponent();

            // Создаём сервис
            string filePath = Path.Combine(Application.StartupPath, "notes.xml");
            _service = new NoteService(new NoteRepository(filePath));

            LoadNotes();
        }

        private void LoadNotes()
        {
            flowLayoutPanelNotes.Controls.Clear();
            _cards.Clear();

            var notes = _service.GetAll();
            foreach (var note in notes)
            {
                AddCardToUI(note);
            }
        }

        private void AddCardToUI(Note note)
        {
            var card = new NoteCard();
            card.LoadFromNote(note);

            // Подписка на клик для расширения (опционально)
            card.Click += Card_Click;

            flowLayoutPanelNotes.Controls.Add(card);
            _cards[note.Id] = card;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (sender is NoteCard clickedCard)
            {
                foreach (var card in flowLayoutPanelNotes.Controls.OfType<NoteCard>())
                {
                    if (card != clickedCard)
                        card.Collapse();
                }

                clickedCard.ToggleExpand(); // карточка увеличивается при клике
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var note = new Note
            {
                Title = "Новая заметка",
                Text = "",
                CreatedAt = DateTime.Now
            };

            _service.Add(note);
            AddCardToUI(note);
        }
    }
}
