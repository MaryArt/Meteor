using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace Dal
{
    public class MagnitudeRepository : IRepository<Magnitude>
    {
        private MyContext _myContext;

        public MagnitudeRepository(MyContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Magnitude> GetAll()
        {
            return _myContext.Magnitudes;
        }

        public Magnitude Get(int id)
        {
            return _myContext.Magnitudes.Find(id);
        }

        public void Create(Magnitude magnitude)
        {
            _myContext.Magnitudes.Add(magnitude);
        }

        public void Update(Magnitude magnitude)
        {
            _myContext.Entry(magnitude).State = EntityState.Modified;
        }

        public IEnumerable<Magnitude> Find(Func<Magnitude, Boolean> predicate)
        {
            return _myContext.Magnitudes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Magnitude magnitude= _myContext.Magnitudes.Find(id);
            if (magnitude == null) return;
            _myContext.Magnitudes.Remove(magnitude);
        }
    }
}
