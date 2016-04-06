using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
