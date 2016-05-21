using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal.Repositories
{
    public class StateRepository : IRepository<State>
    {
        private MeteorContext _myContext;

        public StateRepository(MeteorContext context)
        {
            _myContext = context;
        }

        public IEnumerable<State> GetAll()
        {
            return _myContext.States;
        }

        public State Get(int id)
        {
            return _myContext.States.Find(id);
        }

        public void Create(State state)
        {
            _myContext.States.Add(state);
        }

        public void Update(State state)
        {
            _myContext.Entry(state).State = EntityState.Modified;
        }

        public IEnumerable<State> Find(Func<State, Boolean> predicate)
        {
            return _myContext.States.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            State state = _myContext.States.Find(id);
            if (state == null) return;
            _myContext.States.Remove(state);
        }
    }
}
