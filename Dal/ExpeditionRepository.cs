using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace Dal
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

        public void Create(Expedition expedition)
        {
            _myContext.Expeditions.Add(expedition);
        }

        public void Update(Expedition expedition)
        {
            _myContext.Entry(expedition).State = EntityState.Modified;
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
