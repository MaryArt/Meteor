using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DalFake;
using Dal;
using Model;

namespace Bl
{
    public class MeteorService
    {
        UnitOfWork Database { get; }

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

        public IEnumerable<Meteor> GetMeteorsByInterval(int id)
        {
            var interval = Database.Intervals.Get(id);
            var meteors = interval.Meteors;
            return meteors;
        }
    }
}
