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
        private List<IntervalViewModel> _intervals;
        private List<GroupViewModel> _groups;
        private List<PersonViewModel> _people;
        private List<MeteorViewModel> _meteors;

        private ExpeditionViewModel _selectedExpedition;
        private DayViewModel _selectedDay;
        private IntervalViewModel _selectedInterval;


        private DayService _dayService;
        private IntervalService _intervalService;
        private MeteorService _meteorService;

        public List<ExpeditionViewModel> Expiditions
        {
            get { return _expiditions; }
            set
            {
                _expiditions = value;
                OnPropertyChanged();
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

        public List<IntervalViewModel> Intervals
        {
            get { return _intervals; }
            set
            {
                _intervals = value;
                OnPropertyChanged();
            }
        }

        public List<GroupViewModel> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }


        public List<PersonViewModel> People
        {
            get { return _people; }
            set
            {
                _people = value;
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

        public IntervalViewModel SelectedInterval
        {
            get { return _selectedInterval; }
            set
            {
                _selectedInterval = value;
                OnPropertyChanged();
                if (value == null) return;
                var meteors = _meteorService.GetMeteorsByInterval(value.Id);
                Meteors = Mapper.Map<List<MeteorViewModel>>(meteors);
            }
        }



        public MainViewModel()
        {
            Expiditions = new List<ExpeditionViewModel>
            {
                new ExpeditionViewModel {  Name = "Персеиды", Mission = "ММП", Latitude = 46.67 },
                 new ExpeditionViewModel {  Name = "Ореониды", Mission = "ММП", Latitude = 47.33 }
            };

            Days = new List<DayViewModel>()
            {
                new DayViewModel() {Date = (DateTime.Now).ToShortDateString()},
                new DayViewModel() {Date = ((DateTime.Now).AddDays(1)).ToShortDateString()},
                new DayViewModel() {Date = ((DateTime.Now).AddDays(4)).ToShortDateString()},
            };

            Intervals = new List<IntervalViewModel>()
            {
                new IntervalViewModel()
                {
                    Clouds = 50,
                    Group = new GroupViewModel() {Name = "Зеленые"},
                    Moon = 30,
                    MoonHeight = 24,
                    TimeBegin = (DateTime.Now).ToLongTimeString(),
                    TimeEnd = ((DateTime.Now).AddMinutes(40)).ToLongTimeString()
                }
            };

            People = new List<PersonViewModel>()
            {
                new PersonViewModel() { Name = "Петр", Surname = "Петров", MiddleName = "Петрович"},
                new PersonViewModel() { Name = "Иван", Surname = "Иванов", MiddleName = "Иванович"}
            };
            Groups = new List<GroupViewModel>()
            {
                new GroupViewModel()
                {
                    Name = "Зеленые",
                    Group_People = new List<Group_PersonViewModel>()
                    {
                        new Group_PersonViewModel() { Person = People[0], Program = "квалифицированный счет", Role = "наблюдатель"},
                        new Group_PersonViewModel() { Person = People[1], Program = "квалифицированный счет", Role = "руководитель"}
                    }
                }
                
            };
            
            Meteors = new List<MeteorViewModel>()
            {
                new MeteorViewModel()
                {
                    Number = 1,
                    Length = 14,
                    Duration = 0.5,
                    Speed = 4,
                    Color = 1,
                    Contour = 2,
                    Zenit = 45,
                    P = 5,
                    PPrime = 8,
                    Notes = "вспышка",
                    TraceLength = 13,
                    TraceDuration = 2,
                    TraceContour = 3,
                    Source = "Водолей", 
                    Magnitudes = new List<MagnitudeViewModel>()
                    {
                        new MagnitudeViewModel() {  MagnitudeValue = 3.4, },
                        new MagnitudeViewModel() { MagnitudeValue = -1}
                    }
                }
            };


            //задаем функцию которую будет выполнять команда
            //команда нужна для того чтобы потом привязать ее к контролам на форме
            BestCommandEver = new DelegateCommand<ExpeditionViewModel>(HelloWorld);

            _dayService = new DayService();
            _intervalService = new IntervalService();
            _meteorService = new MeteorService();
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
