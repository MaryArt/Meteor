using System;
using System.Collections.Generic;
using Dal;
using Model;

namespace Bl.Services
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
