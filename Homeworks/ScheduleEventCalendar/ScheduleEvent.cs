using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleEventCalendar
{
    public class ScheduleEvent
    {
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
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
