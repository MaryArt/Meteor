using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Dal.Repositories
{
    public class DayRepository : IRepository<Day>
    {
        private MeteorContext _myContext;

        public DayRepository(MeteorContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Day> GetAll()
        {
            return _myContext.Days;
        }

        public Day Get(int id)
        {
            var day = _myContext.Days.Find(id);
            
            //_myContext.Entry(day)
            return day;

        }

        public void Create(Day state)
        {
            _myContext.Days.Add(state);
        }

        public void Update(Day state)
        {
            _myContext.Entry(state).State = EntityState.Modified;
        }

        public IEnumerable<Day> Find(Func<Day, Boolean> predicate)
        {
            return _myContext.Days.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Day day = _myContext.Days.Find(id);
            if (day == null) return;
            _myContext.Days.Remove(day);
        }
    }
}
