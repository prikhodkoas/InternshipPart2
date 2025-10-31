using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleEventCalendar
{
    /// <summary>
    /// Событие
    /// </summary>
    public class ScheduleEvent
    {
        /// <summary>
        /// Название события
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Дата события
        /// </summary>
        public DateTime EventDate { get; set; }
        /// <summary>
        /// Категория события
        /// </summary>
        public string Category { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;
            if (obj is ScheduleEvent se)
                return this.Title == se.Title && this.EventDate == se.EventDate && this.Category == se.Category;
            return false;
        }
    }
}
