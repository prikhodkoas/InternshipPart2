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
        private CalendarPanel calendarPanel;
        private EventInfoPanel infoPanel;

        public EventViewer()
        {
            InitializeComponent();
            calendarPanel = new CalendarPanel();
            infoPanel = new EventInfoPanel();

            this.calendarPanel.Dock = DockStyle.Fill;
            infoPanel.Dock = DockStyle.Right;
            infoPanel.Width = 200;

            calendarPanel.EventSelected += OnEventSelected;
            calendarPanel.EventDropped += OnEventDropped;

            this.Controls.Add(calendarPanel);
            this.Controls.Add(infoPanel);
        }

        private void OnEventSelected(object sender, ScheduleEvent evt)
        {
            infoPanel.DisplayEvent(evt);
        }

        private void OnEventDropped(object sender, ScheduleEvent evt)
        {
            // Обновить событие в модели
        }

        public void AddEvent(ScheduleEvent evt) => calendarPanel.AddEvent(evt);
        public void RemoveEvent(ScheduleEvent evt) => calendarPanel.RemoveEvent(evt);
    }
}
