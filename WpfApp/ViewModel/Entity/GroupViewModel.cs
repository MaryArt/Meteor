using System.Collections.Generic;

namespace WpfApp.ViewModel.Entity
{
     public class GroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Group_PersonViewModel> Group_People { get; set; }
    }
}
