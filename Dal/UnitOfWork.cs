using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal
{
    public class UnitOfWork /*: IUnitOfWork*/
    {
        private MyContext _myContext;
        private MeteorRepository _meteorRepository;
        private ExpeditionRepository _expeditionRepository;
        private MagnitudeRepository _magnitudeRepository;

        public UnitOfWork()
        {
            _myContext = new MyContext();
        }

        public IRepository<Meteor> Meteors
        {
            get { return _meteorRepository ?? (_meteorRepository = new MeteorRepository(_myContext)); }
        }

        public IRepository<Expedition> Expeditions
        {
            get { return _expeditionRepository ?? (_expeditionRepository = new ExpeditionRepository(_myContext)); }
        }

        public IRepository<Magnitude> Magnitudes
        {
            get { return _magnitudeRepository ?? (_magnitudeRepository = new MagnitudeRepository(_myContext)); }
        }


        public void Save()
        {
            _myContext.SaveChanges();
        }

        //private bool _disposed;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            _myContext.Dispose();
        //        }
        //        _disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
