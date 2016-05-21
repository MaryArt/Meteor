using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp.ViewModel
{
    public class DayViewModel
    {
        public int Id { get; set; }


        public string Date { get; set; }

        //public string DateString => Date.ToShortDateString();

        public int ExpeditionId { get; set; }

        //public virtual ICollection<IntervalViewModel> Intervals { get; set; }


    }
}
