using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DalFake
{
    public class ExpeditionRepository 
    {
        private MyContext _myContext;

        public ExpeditionRepository(MyContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Expedition> GetAll()
        {
            return _myContext.Expeditions;
        }

        public Expedition Get(int id)
        {
            return _myContext.Expeditions.Find(m => m.Id == id);
        }

        public void Create(Expedition expedition)
        {
            _myContext.Expeditions.Add(expedition);
        }

        public void Update(Expedition expedition)
        {
            var i = _myContext.Expeditions.IndexOf(_myContext.Expeditions.First(m => m.Id == expedition.Id));
            _myContext.Expeditions[i] = expedition;
        }

        public IEnumerable<Expedition> Find(Func<Expedition, bool> predicate)
        {
            return _myContext.Expeditions.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var expedition = _myContext.Expeditions.Find(m => m.Id == id);
            if (expedition == null) return;
            _myContext.Expeditions.Remove(expedition);
        }
    }
}
