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
using System.Windows.Shapes;
using AutoMapper;
using Bl.Services;
using Model;
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for NewExpedition.xaml
    /// </summary>
    public partial class NewExpedition : Window
    {
        private ExpeditionService _expeditionService;

        public NewExpedition()
        {
            InitializeComponent();
            _expeditionService = new ExpeditionService();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var expedition = ((NewExpeditionViewModel) this.DataContext).NewExpedition;
            var exp = Mapper.Map<Expedition>(expedition);
            if (_expeditionService.AddExpedition(exp) == true)
            {
                this.Close();
            }
        }
    }
}
