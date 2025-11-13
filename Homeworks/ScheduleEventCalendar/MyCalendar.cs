using System;
using System.Windows.Forms;

/// <summary>
/// ПОльзовательский календарь для контрола
/// </summary>
public class MyCalendar : MonthCalendar
{
    public MyCalendar()
    {
        this.ContextMenuStrip = null;
    }

    /// <summary>
    /// Переопределение события показа системного контекстного меню для календаря
    /// </summary>
    protected override void WndProc(ref Message m)
    {
        const int WM_CONTEXTMENU = 0x007B;

        if (m.Msg == WM_CONTEXTMENU)
            return;

        base.WndProc(ref m);
    }
}
