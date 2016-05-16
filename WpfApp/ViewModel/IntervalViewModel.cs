using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace WpfApp.ViewModel
{
    public class IntervalViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public DateTime TimeBegin { get; set; }

        public DateTime TimeEnd { get; set; }

        public double Clouds { get; set; }

        public double Moon { get; set; }

        public int MoonHeight { get; set; }

        public int RadiantHeight { get; set; }

        public DayViewModel Day { get; set; }

        public GroupViewModel Group { get; set; }

        public virtual ICollection<MeteorViewModel> Meteors { get; set; }

        public virtual ICollection<StateViewModel> States { get; set; }

    }
}
