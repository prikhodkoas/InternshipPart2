using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleEventCalendar
{
    public partial class EventViewer: UserControl
    {
        /// <summary>
        /// Структура данных для храния событий контрола
        /// </summary>
        private Dictionary<DateTime, List<ScheduleEvent>> _events = new Dictionary<DateTime, List<ScheduleEvent>>();

        public EventViewer()
        {
            InitializeComponent();
            Application.AddMessageFilter(new CalendarContextMenuBlocker(monthCalendar));

        }

        private void AddEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateEventToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DeleteEventToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CalendarWrapper_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var date = GetDateFromPoint(e.Location);
                if (date.HasValue)
                {
                    monthCalendar.SetDate(date.Value);
                    contextMenuStripCalendar.Show(calendarWrapper, e.Location);
                }
            }
        }

        private DateTime? GetDateFromPoint(Point location)
        {
            var relativePoint = monthCalendar.PointToClient(location);
            var hit = monthCalendar.HitTest(relativePoint);

            if (hit.HitArea == MonthCalendar.HitArea.Date)
            {
                return hit.Time;
            }

            return null;
        }

    }
}
