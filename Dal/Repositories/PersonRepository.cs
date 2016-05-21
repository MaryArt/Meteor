using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private MeteorContext _myContext;

        public PersonRepository(MeteorContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return _myContext.People;
        }

        public Person Get(int id)
        {
            return _myContext.People.Find(id);
        }

        public void Create(Person state)
        {
            _myContext.People.Add(state);
        }

        public void Update(Person state)
        {
            _myContext.Entry(state).State = EntityState.Modified;
        }

        public IEnumerable<Person> Find(Func<Person, Boolean> predicate)
        {
            return _myContext.People.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Person person = _myContext.People.Find(id);
            if (person == null) return;
            _myContext.People.Remove(person);
        }
    }
}
