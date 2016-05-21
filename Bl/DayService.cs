using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dal;
using Model;

namespace Bl
{
    public  class DayService
    {
        UnitOfWork Database { get; set; }

        public DayService()
        {
            Database = new UnitOfWork();
        }

        public IEnumerable<Day> GetAllDaysByExpeditionId(int expeditionId)
        {
            if (expeditionId <= 0) throw new ArgumentOutOfRangeException(nameof(expeditionId));
            var expedition = Database.Expeditions.Get(expeditionId);
            return expedition.Days;
        }
    }
}
