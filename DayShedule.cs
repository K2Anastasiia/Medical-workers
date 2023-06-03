#region Namespace directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
#endregion

namespace Victor.Timetable
{
    [Serializable]
    public class DayShedule : Dictionary<TimeSpan, string>
    {
        public DayOfWeek DayOfWeek { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public TimeSpan Duration { get; private set; }
        public TimeSpan Interval { get; private set; }
        public bool IsSet { get; private set; }
        public bool IsExpired => DateTime.Today > Date;

        protected DayShedule(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            DayOfWeek = (DayOfWeek)info.GetValue("DayOfWeek", typeof(DayOfWeek));
            IsSet = info.GetBoolean("IsSet");
            if (!IsSet)
                return;
            Date = info.GetDateTime("Date");
            StartTime = (TimeSpan)info.GetValue("StartTime", typeof(TimeSpan));
            EndTime = (TimeSpan)info.GetValue("EndTime", typeof(TimeSpan));
            Duration = (TimeSpan)info.GetValue("Duration", typeof(TimeSpan));
            Interval = (TimeSpan)info.GetValue("Interval", typeof(TimeSpan));
        }
        
        /// <summary>
        /// Ініціалізує новий екземпляр класу DayShedule для вказаного дня тижня
        /// </summary>
        /// <param name="day">День тижня</param>
        public DayShedule(DayOfWeek day)
        {
            DayOfWeek = day;
        }

        /// <summary>
        /// Встановлює розклад роботи з заданими часами та інтервалом
        /// </summary>
        /// <param name="startTime">Початковий час</param>
        /// <param name="endTime">Кінцевий час</param>
        /// <param name="interval">Інтервал</param>
        /// <exception cref="ArgumentException">Виникає, якщо задано невірні часи або інтервал</exception>
        public void Set(TimeSpan startTime, TimeSpan endTime, TimeSpan interval)
        {
            if (startTime.Days > 0)
                throw new ArgumentException("Початковий час задано невірно");
            if (endTime.Days > 0)
                throw new ArgumentException("Кінцевий час задано невірно");
            if (startTime >= endTime)
                throw new ArgumentException("Початковий час має бути більшим від кінцевого");
            StartTime = startTime;
            EndTime = endTime;
            Duration = EndTime - StartTime;
            if (interval > Duration)
                throw new ArgumentException("Інтервал перевищує робочий проміжок");
            IsSet = true;
            Interval = interval;
            SetNextDateOfDayOfWeek();
            Clear();
            TimeSpan floatBound = StartTime;
            while (floatBound < EndTime)
            {
                Add(floatBound, string.Empty);
                floatBound += interval;
            }
        }

        /// <summary>
        /// Скасовує встановлений розклад роботи
        /// </summary>
        public void Unset()
        {
            IsSet = false;
        }

        /// <summary>
        /// Синхронізує дату розкладу з поточною датою. Видаляє завдання, які застаріли
        /// </summary>
        public void SyncDate()
        {
            if (IsExpired)
            {
                double delta = (DateTime.Today - Date).TotalDays / 7;
                var factor = (int)(Math.Abs((int)delta - delta) < double.Epsilon ? delta : delta + 1);
                Date += new TimeSpan(factor * 7, 0, 0, 0);
                ClearTasks();
            }
        }

        /// <summary>
        /// Очищає всі завдання в розкладі
        /// </summary>
        private void ClearTasks()
        {
            foreach (TimeSpan time in Keys.ToList())
                this[time] = string.Empty;
        }

        /// <summary>
        /// Встановлює наступну дату зазначеного дня тижня у розкладі
        /// </summary>
        private void SetNextDateOfDayOfWeek()
        {
            Date = DateTime.Today;
            while (Date.DayOfWeek != DayOfWeek)
                Date = Date.AddDays(1);
        }

        /// <summary>
        /// Викликається під час серіалізації об'єкта для збереження його даних
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("DayOfWeek", DayOfWeek);
            info.AddValue("IsSet", IsSet);
            if (!IsSet)
                return;
            info.AddValue("Date", Date);
            info.AddValue("StartTime", StartTime);
            info.AddValue("EndTime", EndTime);
            info.AddValue("Duration", Duration);
            info.AddValue("Interval", Interval);
        }
    }
}

