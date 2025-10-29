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
        private ScheduleEvent _scheduleEvent { get; set; } = new ScheduleEvent();
        public EditEventForm(ScheduleEvent se)
        {
            _scheduleEvent = se;
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            _scheduleEvent.Title = TitleTxtBx.Text;
            _scheduleEvent.StartTime = StartTimeDtTmPckr.Value;
            _scheduleEvent.EndTime = EndTimeDtTmPckr.Value;
            _scheduleEvent.Category = CategoryCmbBx.SelectedItem as string;
        }
    }
}
