using System;
using System.Collections.Generic;
using System.Linq;
using Dal;
using Model;
//using DalFake;

namespace Bl.Services
{
    public class ExpeditionService
    {
        UnitOfWork Database { get; set; }

        public ExpeditionService()
        {
            Database = new UnitOfWork();
        }

        public IEnumerable<Expedition> GetAllExpeditions()
        {
            var expeditions = Database.Expeditions.GetAll().ToList();
            if (expeditions == null) { throw new ArgumentNullException("Expeditions not found", ""); }
            return expeditions;
        }

        public bool AddExpedition(Expedition expedition)
        {
            Database.Expeditions.Create(expedition);
            Database.Save();
            return true;
        }

        public Expedition Get(int id)
        {
            return Database.Expeditions.Get(id);
        }
    }
}
