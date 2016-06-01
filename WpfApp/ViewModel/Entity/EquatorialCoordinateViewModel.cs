namespace WpfApp.ViewModel.Entity
{
    public class EquatorialCoordinateViewModel
    {
        public int Id { get; set; }

        public double Declension { get; set; }

        public double HourAngle { get; set; }

        public MeteorViewModel Meteor { get; set; }
    }
}
