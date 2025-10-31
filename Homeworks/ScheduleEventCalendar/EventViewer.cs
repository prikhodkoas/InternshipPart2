using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleEventCalendar
{
    public partial class EventViewer : UserControl
    {
        public Dictionary<DateTime, List<ScheduleEvent>> Events { get; set; } = new Dictionary<DateTime, List<ScheduleEvent>>();
        
        public Dictionary<string, Color> Categories { get; set; }

        public event EventHandler<DateTime> DateSelected;
        public event EventHandler<ScheduleEvent> EventSelected;
        public event EventHandler<ScheduleEvent> EventDragged;
        public event EventHandler<DateTime> EventDroppedOnDate;
        public event EventHandler AddEventRequested;
        public event EventHandler EditEventRequested;
        public event EventHandler DeleteEventRequested;
        public event EventHandler OnCategoryChanged;

        #region Logic of Control
        /// <summary>
        /// События, привязанные к датам календаря
        /// </summary>

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
            AddEventRequested?.Invoke(this, EventArgs.Empty);

            var selectedDate = monthCalendar.SelectionStart;

            using (var form = new AddEventForm(selectedDate))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newEvent = form.CreatedEvent;

                    if (!Events.ContainsKey(selectedDate))
                        Events[selectedDate] = new List<ScheduleEvent>();

                    Events[selectedDate].Add(newEvent);
                }
            }
            LoadEventsForDate(selectedDate);
        }

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadEventsForDate(e.End);
            DateSelected?.Invoke(this, e.End);
        }

        private void LoadEventsForDate(DateTime date)
        {   
            LstBxEvents.DataSource = null;

            if (Events.TryGetValue(date.Date, out var eventsForDate) && eventsForDate.Count > 0)
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
            EditEventRequested?.Invoke(this, EventArgs.Empty);

            if (LstBxEvents.SelectedItem is ScheduleEvent selectedEvent)
            {
                var oldDate = selectedEvent.EventDate; // Запоминаем старую дату

                using (var form = new EditEventForm(selectedEvent))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var updatedEvent = form.ChangedEvent;

                        // Если дата изменилась — переносим событие в другую дату
                        if (oldDate.Date != updatedEvent.EventDate.Date)
                        {
                            if (Events.ContainsKey(oldDate))
                                Events[oldDate].Remove(selectedEvent);

                            if (!Events.ContainsKey(updatedEvent.EventDate.Date))
                                Events[updatedEvent.EventDate.Date] = new List<ScheduleEvent>();

                            Events[updatedEvent.EventDate.Date].Add(updatedEvent);
                        }
                        else
                        {
                            // Обновляем поля у старого объекта (если дата не изменилась)
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
                        EventSelected?.Invoke(this, scheduleEvent);
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
                    if (Events.ContainsKey(movedEvent.EventDate))
                        Events[movedEvent.EventDate].Remove(movedEvent);

                    // Добавляем в новую дату
                    movedEvent.EventDate = newDate;
                    
                    if (!Events.ContainsKey(newDate))
                        Events[newDate] = new List<ScheduleEvent>();

                    Events[newDate].Add(movedEvent);

                    LoadEventsForDate(monthCalendar.SelectionStart);
                }
            }
        }

        private void DeleteEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEventRequested?.Invoke(this, EventArgs.Empty);
            if (LstBxEvents.SelectedItem is ScheduleEvent selectedEvent)
            {
                var date = selectedEvent.EventDate;

                if (Events.ContainsKey(date))
                {
                    Events[date].Remove(selectedEvent);

                    if (Events[date].Count == 0)
                        Events.Remove(date);
                }

                LoadEventsForDate(date);
            }
        }
        #endregion
    }
}
