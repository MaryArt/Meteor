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

        public int GetCount(double m, int Z, string source)
        {
            var count = Database.Meteors.Find(x => x.AverageMagnitude < m || x.Zenit < Z || x.Source.Equals(source)).Count();
            return count;
        }

        public List<Meteor> GetMeteorByPredicate(Func<Meteor, Boolean> predicate)
        {
            return Database.Meteors.Find(predicate).ToList();
        }

        public List<Meteor> GetMeteorsByExpeditionId(int id)
        {
            var exp = Database.Expeditions.Find(x => x.Id==id).First();
            if(exp == null) return new List<Meteor>(); //TODO: надо сказать пользователю что экспедиция не найдена
            var meteors = new List<Meteor>();
            foreach (var day in exp.Days)
            {
                foreach (var interval in day.Intervals)
                {
                    meteors.AddRange(interval.Meteors);
                }
            }
            return meteors;
            //return Database.Meteors.Find(x => x.Interval.Day.Expedition.Id == id).ToList();
        }

        public int GetCount(int id, double m, int z, string source)
        {
            var meteors = Database.Intervals.Get(id).Meteors;
            var count = meteors.Count(x => x.AverageMagnitude < m || x.Zenit < z || x.Source.Equals(source));
            return count;
        }
    }
}
