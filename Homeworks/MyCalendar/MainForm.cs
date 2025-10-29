using System.Windows.Forms;

using ScheduleEventCalendar;

namespace MyCalendar
{
    public partial class MainForm : Form
    {
        private EventViewer eventViewer;

        public MainForm()
        {
            InitializeComponent();
            InitializeEventViewer();
        }

        private void InitializeEventViewer()
        {
            eventViewer = new EventViewer
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(eventViewer);
        }
    }
}
