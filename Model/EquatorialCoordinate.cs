using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EquatorialCoordinate
    {
        [Key]
        public int Id { get; set; }

        public double Declension { get; set; }

        public double HourAngle { get; set; }

        [Required]
        public Meteor Meteor { get; set; }
    }
}
