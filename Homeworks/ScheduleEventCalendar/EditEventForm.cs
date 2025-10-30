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
        public ScheduleEvent CreatedEvent { get; private set; } = new ScheduleEvent();

        public EditEventForm(ScheduleEvent se)
        {
            CreatedEvent = se;
            InitializeComponent();
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
            Close();
        }
    }
}
