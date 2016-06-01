using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using Bl;
using Bl.Services;
using Microsoft.Practices.Prism.Commands;
using Model;
using WpfApp.ViewModel.Entity;

namespace WpfApp.ViewModel
{
    public class NewExpeditionViewModel : INotifyPropertyChanged 
    {
        private List<ExpeditionViewModel> _expiditions;
        private ExpeditionViewModel _expedition;

        private ExpeditionService _expeditionService;

        public ExpeditionViewModel NewExpedition
        {
            get { return _expedition; }
            set
            {
                _expedition = value;
                OnPropertyChanged();
            }
        }

        
        public NewExpeditionViewModel()
        {
            NewExpedition = new ExpeditionViewModel();

            _expeditionService = new ExpeditionService();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public ICommand BestCommandEver { get; set; }

        /// <summary>
        /// функция которую выполняет команда
        /// </summary>
        /// <param name="expidition">выбранная(выделенная) експедиция</param>
        private void HelloWorld(ExpeditionViewModel expidition)
        {
            var exp = Mapper.Map<Expedition>(expidition);
            if (_expeditionService.AddExpedition(exp) == true)
            {
                
            }
        }
    }
}
