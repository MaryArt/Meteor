using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Meteor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime Time { get; set; }
        
        public string Length { get; set; }

        public double Duration { get; set; }

        
        public int Speed { get; set; }

        public int Color { get; set; }
        
        public int Contour { get; set; }

        [Required]
        public int Zenit { get; set; }
        
        public double P { get; set; }
        
        public double PPrime { get; set; }
        
        public string Notes { get; set; }
        
        public double Trace { get; set; }
        
        public string Source { get; set; }
        
        public Interval Interval { get; set; } 
        
    }
}
