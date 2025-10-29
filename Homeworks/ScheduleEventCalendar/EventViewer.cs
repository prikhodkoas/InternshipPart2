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

        private void MonthCalendar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Получаем дату под курсором
                DateTime? clickedDate = GetDateFromPoint(e.Location);
                if (clickedDate.HasValue)
                {
                    // Сохраняем выбранную дату, если нужно
                    monthCalendar.SetDate(clickedDate.Value);

                    // Показываем контекстное меню
                    contextMenuStripCalendar.Show(monthCalendar, e.Location);
                }
            }
        }
        private DateTime? GetDateFromPoint(Point location)
        {
            var hit = monthCalendar.HitTest(location);
            if (hit.HitArea == MonthCalendar.HitArea.Date)
            {
                return hit.Time;
            }
            return null;
        }
    }
}
