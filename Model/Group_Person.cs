using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class Group_Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Person Person { get; set; }

        [Required]
        public Group Group { get; set; }

        public string Role { get; set; }

        public string Program { get; set; }

    }
}
