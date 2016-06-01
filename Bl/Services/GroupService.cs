using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace Bl.Services
{
    public class GroupService
    {
        UnitOfWork Database { get; set; }

        public GroupService()
        {
            Database = new UnitOfWork();
        }

        public Group GetGroupById(int groupId)
        {
            if (groupId <= 0) throw new ArgumentOutOfRangeException(nameof(groupId));
            var group = Database.Groups.Get(groupId);
            return group;
        }

        public IEnumerable<Group> GetAll()
        {
            return Database.Groups.GetAll();
        }
    }
}
