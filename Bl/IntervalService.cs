using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace Bl
{
    public class IntervalService
    {
        UnitOfWork Database { get; set; }

        public IntervalService()
        {
            Database = new UnitOfWork();
        }

        public IEnumerable<Interval> GetAllIntervalsByDayId(int dayId)
        {
            if (dayId <= 0) throw new ArgumentOutOfRangeException(nameof(dayId));
            var day = Database.Days.Get(dayId);
            day.Intervals.ToList().ForEach(i => i = Database.Intervals.Get(i.Id));
            //var intervals = Database.Intervals.Find(c => c.Day.Id == dayId)
            //context.Entry(course).Reference(c => c.Department).Load();
            return day.Intervals;
        }
    }
}
