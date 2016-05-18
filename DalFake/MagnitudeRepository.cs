using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DalFake
{

    public class MagnitudeRepository
    {
        private MyContext _myContext;

        public MagnitudeRepository(MyContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Magnitude> GetAll()
        {
            var magnitudes = _myContext.Magnitudes;
            return magnitudes;
        }

        public Magnitude Get(int id)
        {
            return _myContext.Magnitudes.Find(m => m.Id == id);
        }

        public void Create(Magnitude magnitude)
        {
            _myContext.Magnitudes.Add(magnitude);
        }

        public void Update(Magnitude magnitude)
        {
            var i = _myContext.Magnitudes.IndexOf(_myContext.Magnitudes.First(m => m.Id == magnitude.Id));
            _myContext.Magnitudes[i] = magnitude;
        }

        public IEnumerable<Magnitude> Find(Func<Magnitude, bool> predicate)
        {
            return _myContext.Magnitudes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var magnitude = _myContext.Magnitudes.Find(m => m.Id == id);
            if (magnitude == null) return;
            _myContext.Magnitudes.Remove(magnitude);
        }
    }
}
