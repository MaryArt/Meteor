using System.Collections.Generic;

namespace WpfApp.ViewModel.Entity
{
    public class MeteorViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Time { get; set; }
        //public string TimeString
        //{
        //    get { return Time.ToLongTimeString(); }

        //    set { Time = Convert.ToDateTime(value); }
        //}

        public int Length { get; set; }
        public double Duration { get; set; }
        public int Speed { get; set; }
        public int Color { get; set; }
        public int Contour { get; set; }
        public int Zenit { get; set; }
        public double P { get; set; }
        public double PPrime { get; set; }
        public string Notes { get; set; }
        public double TraceLength { get; set; }
        public double TraceDuration { get; set; }
        public double TraceContour { get; set; }
        public string Source { get; set; }
        public List<MagnitudeViewModel> Magnitudes { get; set; }
    }
}
