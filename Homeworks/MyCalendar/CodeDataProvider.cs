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
    /// Поставщик данных из кода
    /// </summary>
    internal class CodeDataProvider : IDataProvider
    {
        DataStorage dataStorage = new DataStorage();
        public (Dictionary<DateTime, List<ScheduleEvent>>, Dictionary<string, Color>) GetData() => (dataStorage.Events, dataStorage.Categories);
        
        public void SetData(Dictionary<DateTime, List<ScheduleEvent>> data)
        {
            dataStorage.Events = data;
        }
    }
}
