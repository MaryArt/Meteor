using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            using (Dal.MyContext db = new Dal.MyContext())
            {
                Meteors.ItemsSource = db.Meteors.ToList();
                Expeditions.ItemsSource = db.Expeditions.ToList();
                Days.ItemsSource = db.Days.ToList();
                Intervals.ItemsSource = db.Intervals.ToList();
                People.ItemsSource = db.People.ToList();
                Groups.ItemsSource = db.Groups.ToList();
                Group_Person.ItemsSource = db.Group_Person.ToList();
                Magnitudes.ItemsSource = db.Magnitudes.ToList();
                Coordinates.ItemsSource = db.EquatorialCoordinates.ToList();
                States.ItemsSource = db.States.ToList();

            }
        }

        
    }
}
