using System;
using System.Collections.Generic;
using System.Linq;
using Dal;
using Model;
//using DalFake;

namespace Bl.Services
{
    public class MagnitudeService
    {
        UnitOfWork Database { get; set; }

        public MagnitudeService()
        {
            Database = new UnitOfWork();
        }

        public IEnumerable<Magnitude> GetAllMagnitudes()
        {
            var magnitudes = Database.Magnitudes.GetAll().ToList();
            if (magnitudes == null) { throw new ArgumentNullException("Magnitudes not found", ""); }
            return magnitudes;
        }
    }
}
