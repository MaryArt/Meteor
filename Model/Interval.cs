using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Interval
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }

        public DateTime TimeBegin { get; set; }

        public DateTime TimeEnd { get; set; }

        public double Clouds { get; set; }

        public double Moon { get; set; }

        public int MoonHeight { get; set; }

        public int RadiantHeight { get; set; }

        public Day Day { get; set; }

        public Group Group { get; set; }

        public virtual ICollection<Meteor> Meteors { get; set; }

        public virtual ICollection<State> States { get; set; }

    }
}
