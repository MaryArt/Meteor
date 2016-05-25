using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModel
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string Initials => String.Concat(Surname[0], ".",MiddleName[0],".");

        public override string ToString()
        {
            return Surname + " " + Name[0] + "." + MiddleName[0] + ".";
        }
    }
}
