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
            var selectedDate = monthCalendar.SelectionStart;

            using (var form = new AddEventForm(selectedDate))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newEvent = form.CreatedEvent;

                    if (!_events.ContainsKey(selectedDate))
                        _events[selectedDate] = new List<ScheduleEvent>();

                    _events[selectedDate].Add(newEvent);
                }
            }
            LoadEventsForDate(selectedDate);
        }

        private void UpdateEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LstBxEvents.SelectedItem is ScheduleEvent selectedEvent)
            {
                using (var form = new EditEventForm(selectedEvent))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadEventsForDate(selectedEvent.EventDate);
                    }
                }
            }
        }

        private void DeleteEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadEventsForDate(e.End);
        }

        private void LoadEventsForDate(DateTime date)
        {
            LstBxEvents.Items.Clear();

            if (_events.TryGetValue(date.Date, out var eventsForDate))
            {
                foreach (var ev in eventsForDate)
                    LstBxEvents.Items.Add(ev.Title);
            }
            else
            {
                LstBxEvents.Items.Add("Нет событий на выбранную дату");
            }
        }
    }
}
