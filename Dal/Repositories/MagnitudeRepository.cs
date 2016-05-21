using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace Dal.Repositories
{
    public class MagnitudeRepository : IRepository<Magnitude>
    {
        //private MyContext _myContext;
        private MeteorContext _myContext;

        public MagnitudeRepository(MeteorContext context)//(MyContext context)
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

        public void Create(Magnitude state)
        {
            _myContext.Magnitudes.Add(state);
        }

        public void Update(Magnitude state)
        {
            _myContext.Entry(state).State = EntityState.Modified;
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
