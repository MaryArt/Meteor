using System.Collections.Generic;

namespace WpfApp.ViewModel.Entity
{
    public class DayViewModel
    {
        public int Id { get; set; }


        public string Date { get; set; }

        //public string DateString => Date.ToShortDateString();

        public int ExpeditionId { get; set; }

        public virtual List<IntervalViewModel> Intervals { get; set; }


    }
}
