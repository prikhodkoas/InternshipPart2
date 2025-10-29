using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleEventCalendar
{
    public class CalendarContextMenuBlocker : IMessageFilter
    {
        private readonly Control target;

        public CalendarContextMenuBlocker(Control target)
        {
            this.target = target;
        }

        public bool PreFilterMessage(ref Message m)
        {
            const int WM_CONTEXTMENU = 0x007B;

            if (m.Msg == WM_CONTEXTMENU && m.HWnd == target.Handle)
            {
                return true;
            }

            return false;
        }
    }
}
