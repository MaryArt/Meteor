using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class Magnitude
    {
        [Key]
        public int Id { get; set; }
         
        [Required]
        public double MagnitudeValue { get; set; }

        public Person Person { get; set; }

        [Required]
        public Meteor Meteor { get; set; }
        

    }
}
