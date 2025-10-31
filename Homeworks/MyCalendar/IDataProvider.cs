using ScheduleEventCalendar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendar
{
    /// <summary>
    /// Поставщик данных
    /// </summary>
    internal interface IDataProvider
    {
        (Dictionary<DateTime, List<ScheduleEvent>>, Dictionary<string, Color>) GetData();
        void SetData(Dictionary<DateTime, List<ScheduleEvent>> data);
    }
}
