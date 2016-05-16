using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WpfApp.ViewModel
{
    public class StateViewModel
    {
        public int Id { get; set; }

        public double StartLimitMagnitude { get; set; }

        public int StartMood { get; set; }

        public double EndLimitMagnitude { get; set; }

        public int EndMood { get; set; }

        public string Center { get; set; }

        public double Direction { get; set; }

        public PersonViewModel Person { get; set; }

        public IntervalViewModel Interval { get; set; }
    }
}
