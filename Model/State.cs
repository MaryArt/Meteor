using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        public double StartLimitMagnitude { get; set; }

        public int StartMood { get; set; }

        public double EndLimitMagnitude { get; set; }

        public int EndMood { get; set; }

        public string Center { get; set; }

        public double Direction { get; set; }

        public Person Person { get; set; }

        [Required]
        public Interval Interval { get; set; }
    }
}
