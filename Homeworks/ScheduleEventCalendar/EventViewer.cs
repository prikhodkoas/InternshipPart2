using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleEventCalendar
{
    public partial class EventViewer : UserControl
    {
        /// <summary>
        /// События, привязанные к датам календаря
        /// </summary>
        private readonly Dictionary<DateTime, List<ScheduleEvent>> _events = new Dictionary<DateTime, List<ScheduleEvent>>();

        public EventViewer()
        {
            InitializeComponent();

            // Подписка на событие клика календаря
            monthCalendar.MouseDown += MonthCalendar_MouseDown;
        }

        private void MonthCalendar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var date = GetDateFromPoint(e.Location);
                if (date.HasValue)
                {
                    // выделяем дату, по которой кликнули
                    monthCalendar.SetDate(date.Value);

                    // показываем контекстное меню в месте клика
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

        private void AddEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // логика добавления события
            MessageBox.Show("Добавить событие для даты: " + monthCalendar.SelectionStart.ToShortDateString());
        }

        private void UpdateEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // логика редактирования события
            MessageBox.Show("Редактировать событие для даты: " + monthCalendar.SelectionStart.ToShortDateString());
        }

        private void DeleteEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // логика удаления события
            MessageBox.Show("Удалить событие для даты: " + monthCalendar.SelectionStart.ToShortDateString());
        }
    }
}
