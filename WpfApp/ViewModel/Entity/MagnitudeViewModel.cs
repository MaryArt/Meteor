namespace WpfApp.ViewModel.Entity
{
    public class MagnitudeViewModel
    {
        public int Id { get; set; }
         
        public double MagnitudeValue { get; set; }
        public PersonViewModel Person { get; set; }

        public MeteorViewModel Meteor { get; set; }
        

    }
}
