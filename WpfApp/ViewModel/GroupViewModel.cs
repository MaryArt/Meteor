using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp.ViewModel
{
     public class GroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Group_PersonViewModel> Group_People { get; set; }
    }
}
