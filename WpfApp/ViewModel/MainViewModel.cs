using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace WpfApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged // как viewmodel  нужен только для представления данных
    {

        private List<ExpeditionViewModel> _expiditions;
        private List<MeteorViewModel> _meteors;


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

        public ExpeditionViewModel Selected { get; set; }

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
