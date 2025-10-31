using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleEventCalendar
{
    public partial class EditEventForm : Form
    {
        public ScheduleEvent ChangedEvent { get; private set; } = new ScheduleEvent();

        public EditEventForm(ScheduleEvent changedEvent)
        {
            ChangedEvent = changedEvent;

            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
 
            TitleTxtBx.Text = changedEvent.Title;
            EventDateDtTmPckr.Value = changedEvent.EventDate;
            //CategoryCmbBx.Items
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TitleTxtBx.Text))
            {
                MessageBox.Show("Введите название события.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ChangedEvent.Title = TitleTxtBx.Text;
            ChangedEvent.EventDate = EventDateDtTmPckr.Value;
            ChangedEvent.Category = CategoryCmbBx.SelectedItem as string;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
