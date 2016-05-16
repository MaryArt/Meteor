using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WpfApp.ViewModel
{
    public class MagnitudeViewModel
    {
        public int Id { get; set; }
         
        public double MagnitudeValue { get; set; }
        public PersonViewModel Person { get; set; }

        public MeteorViewModel Meteor { get; set; }
        

    }
}
