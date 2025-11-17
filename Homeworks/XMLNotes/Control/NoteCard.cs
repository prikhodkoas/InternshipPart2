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

        public event EventHandler Clicked;
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;


        public NoteCard()
        {
            InitializeComponent();

            // Прокрутка мышью
            RegisterMouseWheel(this);
        }
        public void SetControlsIsReadOnly(bool readOnly)
        {
            TitleTextBox.ReadOnly = readOnly;
            TextRichTextBox.ReadOnly = readOnly;

            // Для DateTimePicker просто блокируем изменение
            CreatedAtDateTimePicker.Enabled = !readOnly;
        }

        private void NoteCard_Click(object sender, EventArgs e)
        {
            SetControlsIsReadOnly(false);
        }

        /// <summary>
        /// Прокрутка для каждого элемента карточки 
        /// </summary>
        /// <param name="control">Элемент</param>
        private void RegisterMouseWheel(Control control)
        {
            control.MouseWheel += Control_MouseWheel;
            foreach (Control ctrl in control.Controls)
            {
                RegisterMouseWheel(ctrl);
            }
        }

        /// <summary>
        /// Обработчик прокрутки контрола
        /// </summary>
        private void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.Parent is FlowLayoutPanel panel)
            {
                int newValue = panel.VerticalScroll.Value - e.Delta;
                newValue = Math.Max(panel.VerticalScroll.Minimum, Math.Min(panel.VerticalScroll.Maximum, newValue));
                panel.VerticalScroll.Value = newValue;
                panel.PerformLayout();
            }
        }
    }
}
