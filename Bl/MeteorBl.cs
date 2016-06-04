using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Bl
{
    public class MeteorBl
    {
        public Meteor Meteor { get; set; }

        public double AbsoluteMagnitude { get; set; }

        public int RoundAbsoluteMagnitude => (int)Math.Round(AbsoluteMagnitude);

    }
}
