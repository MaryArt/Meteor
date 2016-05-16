using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalFake;
using Model;

namespace Bl
{
    public class MeteorService
    {
        UnitOfWork Database { get; set; }

        public MeteorService()
        {
            Database = new UnitOfWork();
        }

        public IEnumerable<Meteor> GetAllMeteors()
        {
            var meteors = Database.Meteors.GetAll().ToList();
            if (meteors == null) { throw new ArgumentNullException("Meteors not found", ""); }
            return meteors;
        }
    }
}
