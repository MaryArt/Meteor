using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DalFake
{

    public class MeteorRepository 
    {
        private MyContext _myContext;

        public MeteorRepository(MyContext context)
        {
            _myContext = context;
        }

        public IEnumerable<Meteor> GetAll()
        {
            var meteors = _myContext.Meteors;
            return meteors;
        }

        public Meteor Get(int id)
        {
            return _myContext.Meteors.Find(m => m.Id == id);
        }

        public void Create(Meteor meteor)
        {
            _myContext.Meteors.Add(meteor);
        }

        public void Update(Meteor meteor)
        {
            var i = _myContext.Meteors.IndexOf(_myContext.Meteors.First(m => m.Id == meteor.Id));
            _myContext.Meteors[i] = meteor;
        }

        public IEnumerable<Meteor> Find(Func<Meteor, bool> predicate)
        {
            return _myContext.Meteors.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var meteor = _myContext.Meteors.Find(m => m.Id == id);
            if (meteor == null) return;
            _myContext.Meteors.Remove(meteor);
        }
    }
}
