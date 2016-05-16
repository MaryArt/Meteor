using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WpfApp.ViewModel
{
    public class Group_PersonViewModel
    {
        public int Id { get; set; }

        public PersonViewModel Person { get; set; }

        public GroupViewModel Group { get; set; }

        public string Role { get; set; }

        public string Program { get; set; }

    }
}
