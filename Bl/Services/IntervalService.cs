using System;
using System.Collections.Generic;
using System.Linq;
using Dal;
using Model;

namespace Bl.Services
{
    public class IntervalService
    {
        /*public*/private UnitOfWork Database { get; set; }

        public IntervalService()
        {
            Database = new UnitOfWork();
        }

        public IEnumerable<Interval> GetAllIntervalsByDayId(int dayId)
        {
            if (dayId < 0) throw new ArgumentOutOfRangeException(nameof(dayId));
            var day = Database.Days.Get(dayId);
            day.Intervals.ToList().ForEach(i => i = Database.Intervals.Get(i.Id));
            return day.Intervals;
        }

        public Interval GetInterval(int id)
        {
            return Database.Intervals.Get(id);
        }
    }
}
