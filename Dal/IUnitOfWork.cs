using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal
{
    public interface IUnitOfWork /*: IDisposable*/
    {
        IRepository<Meteor> Meteors { get; }
        IRepository<Magnitude> Magnitudes { get; }
        IRepository<Expedition> Expeditions { get; }
        void Save();
    }
}
