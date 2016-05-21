using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace Dal.Repositories
{

    public class MeteorRepository : IRepository<Meteor>
    {
        //private MyContext _myContext;
        private MeteorContext _myContext;

        public MeteorRepository(MeteorContext context)//(MyContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Meteor> GetAll()
        {
            return _myContext.Meteors;
        }

        public Meteor Get(int id)
        {
            return _myContext.Meteors.Find(id);
        }

        public void Create(Meteor state)
        {
            _myContext.Meteors.Add(state);
        }

        public void Update(Meteor state)
        {
            _myContext.Entry(state).State = EntityState.Modified;
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
