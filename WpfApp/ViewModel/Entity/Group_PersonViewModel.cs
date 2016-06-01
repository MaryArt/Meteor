namespace WpfApp.ViewModel.Entity
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
