using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal.Repositories
{
    public class IntervalRepository : IRepository<Interval>
    {
        private MeteorContext _myContext;

        public IntervalRepository(MeteorContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Interval> GetAll()
        {
            return _myContext.Intervals;
        }

        public Interval Get(int id)
        {
            var day = _myContext.Intervals.Find(id);
            _myContext.Entry(day).Reference(c=>c.Group).Load();
            _myContext.Entry(day).Collection(c => c.Meteors).Load();
            return day;
        }

        public void Create(Interval state)
        {
            _myContext.Intervals.Add(state);
        }

        public void Update(Interval state)
        {
            _myContext.Entry(state).State = EntityState.Modified;
        }

        public IEnumerable<Interval> Find(Func<Interval, Boolean> predicate)
        {
            return _myContext.Intervals.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Interval interval = _myContext.Intervals.Find(id);
            if (interval == null) return;
            _myContext.Intervals.Remove(interval);
        }
    }
}
