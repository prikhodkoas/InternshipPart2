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
    public partial class AddEventForm : Form
    {
        public ScheduleEvent CreatedEvent { get; private set; } = new ScheduleEvent();
        public AddEventForm(DateTime selectedDate)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            EventDateDtTmPckr.Value = selectedDate;
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
            CreatedEvent.Title = TitleTxtBx.Text;
            CreatedEvent.EventDate = EventDateDtTmPckr.Value;
            CreatedEvent.Category = CategoryCmbBx.SelectedItem as string;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
