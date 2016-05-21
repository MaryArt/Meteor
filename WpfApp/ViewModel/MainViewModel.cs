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
using Microsoft.Practices.Prism.Commands;
using Model;

namespace WpfApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged 
    {
        private List<ExpeditionViewModel> _expiditions;
        private List<DayViewModel> _days;
        private List<MeteorViewModel> _meteors;
        private ExpeditionViewModel _selectedExpedition;
        private DayViewModel _selectedDay;
        private List<IntervalViewModel> _intervals;

        private DayService _dayService;
        private IntervalService _intervalService;

        public List<ExpeditionViewModel> Expiditions
        {
            get { return _expiditions; }
            set
            {
                _expiditions = value;
                OnPropertyChanged();
            }
        }

        public List<MeteorViewModel> Meteors
        {
            get { return _meteors; }
            set
            {
                _meteors = value;
                OnPropertyChanged();
            }
        }

        public ExpeditionViewModel SelectedExpedition
        {
            get { return _selectedExpedition; }
            set
            {
                _selectedExpedition = value;
                OnPropertyChanged();
                if (value == null) return;
                Days = Mapper.Map<List<DayViewModel>>(_dayService.GetAllDaysByExpeditionId(value.Id));
            }
        }

        public List<DayViewModel> Days
        {
            get { return _days; }
            set
            {
                _days = value;
                OnPropertyChanged();
            }
        }

        public DayViewModel SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                _selectedDay = value;
                OnPropertyChanged();
                if (value == null) return;
                var intervals = _intervalService.GetAllIntervalsByDayId(value.Id);
                Intervals = Mapper.Map<List<IntervalViewModel>>(intervals);
            }
        }

        public List<IntervalViewModel> Intervals
        {
            get { return _intervals; }
            set
            {
                _intervals = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Expiditions = new List<ExpeditionViewModel>
            {
                new ExpeditionViewModel {  Name = "Персеиды", Mission = "ММП", Latitude = 46.67 },
                 new ExpeditionViewModel {  Name = "Пеftы", Mission = "МnhhП", Latitude = 47 } ,
                  new ExpeditionViewModel {  Name = "Пеtttttы", Mission = "gfg", Latitude = 4 }
            };

            //задаем функцию которую будет выполнять команда
            //команда нужна для того чтобы потом привязать ее к контролам на форме
            BestCommandEver = new DelegateCommand<ExpeditionViewModel>(HelloWorld);

            _dayService = new DayService();
            _intervalService = new IntervalService();
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
            MessageBox.Show("HelloWorld");
            expidition.Name = "HelloWorld";
        }
    }
}
