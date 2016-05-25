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
    }
}
