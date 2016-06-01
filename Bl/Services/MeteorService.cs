using System;
using System.Collections.Generic;
using System.Linq;
using Dal;
using Model;
//using DalFake;

namespace Bl.Services
{
    public class MeteorService
    {
        UnitOfWork Database { get; }

        public MeteorService()
        {
            Database = new UnitOfWork();
        }

        public IEnumerable<Meteor> GetAllMeteors()
        {
            var meteors = Database.Meteors.GetAll().ToList();
            if (meteors == null) { throw new ArgumentNullException("Meteors not found", ""); }
            return meteors;
        }

        public IEnumerable<Meteor> GetMeteorsByInterval(int id)
        {
            var interval = Database.Intervals.Get(id);
            var meteors = interval.Meteors;
            return meteors;
        }

        public int GetGeneralCountOfMeteorByDay(Day day)
        {
            //var count = Database.Meteors.Find(x => x.Interval.Day.Id == day.Id).Count();
            var count = 0;
            foreach (var interval in day.Intervals)
            {
                count += interval.Meteors.Count;
            }
            return count;
        }
        public int GetRadiantCountOfMeteorByDay(Day day, string source)
        {
            var count = 0;
            foreach (var interval in day.Intervals)
            {
                count += (interval.Meteors.Where(m => m.Source == source)).Count();
            }
            return count;
        }
    }
}
