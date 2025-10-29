using System.Windows.Forms;

using ScheduleEventCalendar;

namespace MyCalendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Controls.Add(new EventViewer());
        }
    }
}
