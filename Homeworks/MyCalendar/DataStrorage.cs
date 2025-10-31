using ScheduleEventCalendar;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyCalendar
{
    public class DataStorage
    {
        public Dictionary<DateTime, List<ScheduleEvent>> Events = new Dictionary<DateTime, List<ScheduleEvent>>();

        public Dictionary<string, Color> Categories = new Dictionary<string, Color>
        {
            { "Работа", Color.Red },
            { "Личное", Color.Blue },
            { "Семья", Color.Green },
            { "Отдых", Color.Orange }
        };

        private static readonly Random Rand = new Random();

        public DataStorage()
        {
            DateTime start = new DateTime(2025, 10, 1);
            DateTime end = new DateTime(2025, 10, 31);

            var categoryKeys = new List<string>(Categories.Keys);

            for (int i = 1; i <= 200; i++)
            {
                int dayOffset = Rand.Next((end - start).Days + 1);
                DateTime eventDate = start.AddDays(dayOffset);

                string category = categoryKeys[Rand.Next(categoryKeys.Count)];

                var ev = new ScheduleEvent
                {
                    Title = $"Event #{i}",
                    EventDate = eventDate,
                    Category = category
                };

                if (!Events.ContainsKey(eventDate))
                    Events[eventDate] = new List<ScheduleEvent>();

                Events[eventDate].Add(ev);
            }
        }
    }
}
