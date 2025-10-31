using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendar
{
    /// <summary>
    /// Фабрика для создания поставщика данных
    /// </summary>
    internal static class DataProviderFactory
    {
        public static IDataProvider CreateProvider()
        {
            return new CodeDataProvider();
        }
    }
}
