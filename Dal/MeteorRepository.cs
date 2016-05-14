using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace Dal
{

    public class MeteorRepository : IRepository<Meteor>
    {
        private MeteorDB _myContext;

        public MeteorRepository(MeteorDB context)
        {
            _myContext = context;
        }

        public IEnumerable<Meteor> GetAll()
        {
            var meteors = _myContext.Meteors;
            return meteors;
        }

        public Meteor Get(int id)
        {
            return _myContext.Meteors.Find(id);
        }

        public void Create(Meteor Meteor)
        {
            _myContext.Meteors.Add(Meteor);
        }

        public void Update(Meteor Meteor)
        {
            _myContext.Entry(Meteor).State = EntityState.Modified;
        }

        public IEnumerable<Meteor> Find(Func<Meteor, Boolean> predicate)
        {
            return _myContext.Meteors.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Meteor Meteor = _myContext.Meteors.Find(id);
            if (Meteor == null) return;
            _myContext.Meteors.Remove(Meteor);
        }
    }
}
