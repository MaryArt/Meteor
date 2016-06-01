using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Repositories;
using Model;

namespace Dal
{
    public class UnitOfWork /*: IUnitOfWork*/
    {
        //private MyContext _myContext;
        private MeteorContext _myContext;
        private MeteorRepository _meteorRepository;
        private ExpeditionRepository _expeditionRepository;
        private MagnitudeRepository _magnitudeRepository;
        private DayRepository _dayRepository;
        private IntervalRepository _intervalRepository;
        private GroupRepository _groupRepository;

        public UnitOfWork()
        {
            //_myContext = new MyContext();
            _myContext = new MeteorContext();
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

        public IRepository<Day> Days
        {
            get { return _dayRepository ?? (_dayRepository = new DayRepository(_myContext)); }
        }

        public IRepository<Interval> Intervals
        {
            get { return _intervalRepository ?? (_intervalRepository = new IntervalRepository(_myContext)); }
        }

        public IRepository<Group> Groups
        {
            get { return _groupRepository ?? (_groupRepository = new GroupRepository(_myContext)); }
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
