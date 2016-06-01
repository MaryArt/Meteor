using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private MeteorContext _myContext;

        public GroupRepository(MeteorContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Group> GetAll()
        {
            return _myContext.Groups;
        }

        public Group Get(int id)
        {
            var group = _myContext.Groups.Find(id);
            _myContext.Entry(group).Collection(c => c.Group_People).Load();
            return group;
        }

        public void Create(Group state)
        {
            _myContext.Groups.Add(state);
        }

        public void Update(Group state)
        {
            _myContext.Entry(state).State = EntityState.Modified;
        }

        public IEnumerable<Group> Find(Func<Group, Boolean> predicate)
        {
            return _myContext.Groups.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Group @group = _myContext.Groups.Find(id);
            if (@group == null) return;
            _myContext.Groups.Remove(@group);
        }
    }
}
