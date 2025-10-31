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

            LoadEventsForDate(monthCalendar.TodayDate);

            monthCalendar.AllowDrop = true;

            monthCalendar.MouseDown += MonthCalendar_MouseDown;
            LstBxEvents.MouseDown += LstBxEvents_MouseDown;

            monthCalendar.DragEnter += MonthCalendar_DragEnter;
            monthCalendar.DragDrop += MonthCalendar_DragDrop;
            monthCalendar.DragOver += MonthCalendar_DragOver;
        }

        private void MonthCalendar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var date = GetDateFromPoint(e.Location);
                if (date.HasValue)
                {
                    monthCalendar.SetDate(date.Value);

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

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadEventsForDate(e.End);
        }

        private void LoadEventsForDate(DateTime date)
        {
            LstBxEvents.DataSource = null;

            if (_events.TryGetValue(date.Date, out var eventsForDate) && eventsForDate.Count > 0)
            {
                LstBxEvents.DataSource = eventsForDate;
                LstBxEvents.DisplayMember = "Title";
            }
            else
            {
                LstBxEvents.Items.Clear();
                LstBxEvents.Items.Add("Нет событий на выбранную дату");
            }
        }

        private void UpdateEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LstBxEvents.SelectedItem is ScheduleEvent selectedEvent)
            {
                var oldDate = selectedEvent.EventDate; // запоминаем старую дату

                using (var form = new EditEventForm(selectedEvent))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var updatedEvent = form.ChangedEvent;

                        // Если дата изменилась — переносим событие в другую дату
                        if (oldDate.Date != updatedEvent.EventDate.Date)
                        {
                            if (_events.ContainsKey(oldDate))
                                _events[oldDate].Remove(selectedEvent);

                            if (!_events.ContainsKey(updatedEvent.EventDate.Date))
                                _events[updatedEvent.EventDate.Date] = new List<ScheduleEvent>();

                            _events[updatedEvent.EventDate.Date].Add(updatedEvent);
                        }
                        else
                        {
                            // просто обновляем поля у старого объекта (если дата не изменилась)
                            selectedEvent.Title = updatedEvent.Title;
                            selectedEvent.Category = updatedEvent.Category;
                            selectedEvent.EventDate = updatedEvent.EventDate;
                        }

                        LoadEventsForDate(updatedEvent.EventDate);
                    }
                }
                LoadEventsForDate(oldDate);
            }
        }

        private void LstBxEvents_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = LstBxEvents.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    LstBxEvents.SelectedIndex = index;
                    contextMenuStripEventList.Show(LstBxEvents, e.Location);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                int index = LstBxEvents.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    LstBxEvents.SelectedIndex = index;

                    if (LstBxEvents.SelectedItem is ScheduleEvent scheduleEvent)
                    {
                        // ❗ вызываем у самого списка, не у UserControl
                        LstBxEvents.DoDragDrop(scheduleEvent, DragDropEffects.Move);
                    }
                }
            }
        }

        private void MonthCalendar_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ScheduleEvent)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MonthCalendar_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ScheduleEvent)))
            {
                Point clientPoint = monthCalendar.PointToClient(new Point(e.X, e.Y));

                var date = GetDateFromPoint(clientPoint);

                if (date.HasValue)
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }


        private void MonthCalendar_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ScheduleEvent)))
            {
                var movedEvent = (ScheduleEvent)e.Data.GetData(typeof(ScheduleEvent));

                Point clientPoint = monthCalendar.PointToClient(new Point(e.X, e.Y));
                var hit = monthCalendar.HitTest(clientPoint);

                if (hit.HitArea == MonthCalendar.HitArea.Date)
                {
                    DateTime newDate = hit.Time.Date;

                    // Удаляем из старой даты
                    if (_events.ContainsKey(movedEvent.EventDate))
                        _events[movedEvent.EventDate].Remove(movedEvent);

                    // Добавляем в новую дату
                    movedEvent.EventDate = newDate;
                    
                    if (!_events.ContainsKey(newDate))
                        _events[newDate] = new List<ScheduleEvent>();

                    _events[newDate].Add(movedEvent);

                    LoadEventsForDate(monthCalendar.SelectionStart);
                }
            }
        }
    }
}
