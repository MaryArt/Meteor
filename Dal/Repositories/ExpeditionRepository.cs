using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace Dal.Repositories
{
    public class ExpeditionRepository : IRepository<Expedition>
    {
        //private MyContext _myContext;
        private MeteorContext _myContext;

        //public ExpeditionRepository(MyContext context)
        public ExpeditionRepository(MeteorContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Expedition> GetAll()
        {
            return _myContext.Expeditions;
        }

        public Expedition Get(int id)
        {
            return _myContext.Expeditions.Find(id);
        }

        public void Create(Expedition state)
        {
            _myContext.Expeditions.Add(state);
        }

        public void Update(Expedition state)
        {
            _myContext.Entry(state).State = EntityState.Modified;
        }

        public IEnumerable<Expedition> Find(Func<Expedition, Boolean> predicate)
        {
            return _myContext.Expeditions.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Expedition expedition = _myContext.Expeditions.Find(id);
            if (expedition == null) return;
            _myContext.Expeditions.Remove(expedition);
        }
    }
}
