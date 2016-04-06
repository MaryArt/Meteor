using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class Expedition
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Mission { get; set; }

        public double Latitude { get; set; }

        public virtual ICollection<Day> Days { get; set; }
    }
}
