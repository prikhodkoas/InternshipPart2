using System;
using System.Windows.Forms;

public class MyCalendar : MonthCalendar
{
    public MyCalendar()
    {
        this.ContextMenuStrip = null;
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_CONTEXTMENU = 0x007B;

        if (m.Msg == WM_CONTEXTMENU)
            return;

        base.WndProc(ref m);
    }
}
