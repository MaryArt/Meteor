using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModel
{
    public class EquatorialCoordinateViewModel
    {
        public int Id { get; set; }

        public double Declension { get; set; }

        public double HourAngle { get; set; }

        public MeteorViewModel Meteor { get; set; }
    }
}
