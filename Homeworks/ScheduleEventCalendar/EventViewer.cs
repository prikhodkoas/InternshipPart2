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

        private Panel calendarPanel;
        private Panel infoPanel;

        public EventViewer()
        {
            InitializeComponent();
        }
    }
}
