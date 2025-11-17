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
        private bool isExpanded = false;
        private int collapsedHeight;
        private int expandedHeight = 150;

        public NoteCard()
        {
            InitializeComponent();
            collapsedHeight = this.Height;

            this.Click += NoteCard_Click;
            foreach (Control ctrl in this.Controls)
                ctrl.Click += NoteCard_Click;
        }

        private void NoteCard_Click(object sender, EventArgs e)
        {
            ToggleExpand();
        }

        public void ToggleExpand()
        {
            isExpanded = !isExpanded;
            this.Height = isExpanded ? expandedHeight : collapsedHeight;
        }

        public void Collapse()
        {
            isExpanded = false;
            this.Height = collapsedHeight;
        }

        public void LoadFromNote(Note note)
        {
            Id = note.Id;
            TitleTextBox.Text = note.Title;
            TextRichTextBox.Text = note.Text;
            CreatedAtDateTimePicker.Value = note.CreatedAt;
        }
    }
}
