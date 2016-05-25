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
