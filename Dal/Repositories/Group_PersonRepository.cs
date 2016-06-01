using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Dal.Repositories
{
    public class GroupPersonRepository : IRepository<Group_Person>
    {
        private MeteorContext _myContext;

        public GroupPersonRepository(MeteorContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Group_Person> GetAll()
        {
            return _myContext.Group_Person;
        }

        public Group_Person Get(int id)
        {
            var groupPerson = _myContext.Group_Person.Find(id);
            _myContext.Entry(groupPerson).Reference(c=> c.Person).Load();
            return groupPerson;
        }

        public void Create(Group_Person state)
        {
            _myContext.Group_Person.Add(state);
        }

        public void Update(Group_Person state)
        {
            _myContext.Entry(state).State = EntityState.Modified;
        }

        public IEnumerable<Group_Person> Find(Func<Group_Person, Boolean> predicate)
        {
            return _myContext.Group_Person.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Group_Person groupPerson = _myContext.Group_Person.Find(id);
            if (groupPerson == null) return;
            _myContext.Group_Person.Remove(groupPerson);
        }
    }
}
