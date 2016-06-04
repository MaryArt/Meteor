using System.Collections.Generic;

namespace WpfApp.ViewModel.Entity
{
    public class IntervalViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public string Name
        {
            get
            {
                if (Group != null) return "№" + Number + " (" + Group.Name + ")";
                return Number + " - ???";
            }
        }

        public string TimeBegin { get; set; }

        public string TimeEnd { get; set; }

        //public string TimeBeginString => TimeBegin.ToShortTimeString();

        //public string TimeEndString => TimeEnd.ToShortTimeString();

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
