using System;
using System.Collections.Generic;
using Dal;
using Model;

namespace Bl.Services
{
    public  class DayService
    {
        UnitOfWork Database { get; set; }

        public DayService()
        {
            Database = new UnitOfWork();
        }

        public IEnumerable<Day> GetAllDaysByExpeditionId(int expeditionId)
        {
            if (expeditionId <= 0) throw new ArgumentOutOfRangeException(nameof(expeditionId));
            var expedition = Database.Expeditions.Get(expeditionId);
            return expedition.Days;
        }

        public int GetCountOfMeteorByDay(int id)
        {
            var day = Database.Days.Get(id);
            var count = 0;
            foreach (var interval in day.Intervals)
            {
                count += interval.Meteors.Count;
            }
            return count;
        }

        public double GetClearTimeByDay(int id)
        {
            var day = Database.Days.Get(id);
            double clearTime = 0;
            foreach (var interval in day.Intervals)
            {
                clearTime += interval.TimeEnd.Subtract(interval.TimeBegin).TotalHours;
            }
            return clearTime;
        }
    }
}
