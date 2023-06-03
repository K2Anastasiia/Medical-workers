#region Namespace directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Victor.Timetable
{
    [Serializable]
    public class Timetable : IEnumerable<DayShedule>
    {
        public readonly DayShedule Friday;
        public readonly DayShedule Monday;
        public readonly DayShedule Saturday;
        public readonly DayShedule Sunday;
        public readonly DayShedule Thursday;
        public readonly DayShedule Tuesday;
        public readonly DayShedule Wednesday;
        private readonly List<DayShedule> _days;

        /// <summary>
        /// Конструктор класу Timetable
        /// </summary>
        public Timetable()
        {
            Monday = new DayShedule(DayOfWeek.Monday);
            Tuesday = new DayShedule(DayOfWeek.Tuesday);
            Wednesday = new DayShedule(DayOfWeek.Wednesday);
            Thursday = new DayShedule(DayOfWeek.Thursday);
            Friday = new DayShedule(DayOfWeek.Friday);
            Saturday = new DayShedule(DayOfWeek.Saturday);
            Sunday = new DayShedule(DayOfWeek.Sunday);
            _days = new List<DayShedule>
            {
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Friday,
                Saturday,
                Sunday
            };
        }
        /// <summary>
        /// Індексатор, який повертає день розкладу за заданим індексом
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DayShedule this[int index] => _days[index];

        /// <summary>
        /// Видаляє прострочені записи з розкладу
        /// </summary>
        public void RemoveExpired()
        {
            foreach (DayShedule day in this)
                day.SyncDate();
        }

        /// <summary>
        /// Повертає перечислювач для ітерації через дні розкладу, які мають встановлену інформацію
        /// </summary>
        /// <returns></returns>
        public IEnumerator<DayShedule> GetEnumerator()
        {
            return _days.Where(t => t.IsSet).GetEnumerator();
        }

        /// <summary>
        /// Повертає перечислювач для ітерації через дні розкладу, які мають встановлену інформацію
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
