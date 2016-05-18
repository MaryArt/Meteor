using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DalFake
{
    public class UnitOfWork 
    {
        private MyContext _myContext;
        private MeteorRepository _meteorRepository;
        private ExpeditionRepository _expeditionRepository;
        private MagnitudeRepository _magnitudeRepository;

        public UnitOfWork()
        {
            _myContext = new MyContext();
        }

        public MeteorRepository Meteors
        {
            get { return _meteorRepository ?? (_meteorRepository = new MeteorRepository(_myContext)); }
        }

        public ExpeditionRepository Expeditions
        {
            get { return _expeditionRepository ?? (_expeditionRepository = new ExpeditionRepository(_myContext)); }
        }

        public MagnitudeRepository Magnitudes
        {
            get { return _magnitudeRepository ?? (_magnitudeRepository = new MagnitudeRepository(_myContext)); }
        }

        public void Save()
        {
            _myContext.SaveChanges();
        }

        
    }
}
