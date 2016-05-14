using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Model
{
    public class MainViewModel : INotifyPropertyChanged // как viewmodel  нужен только для представления данных
    {

        private List<Expedition> expiditions;
        private List<Meteor> meteors;


        public List<Expedition> Expiditions
        {
            get { return expiditions; }
            set
            {
                expiditions = value;
                OnPropertyChanged();
            }
        }

        public List<Meteor> Meteors
        {
            get { return meteors; }
            set
            {
                meteors = value;
                OnPropertyChanged();
            }
        }

        public Expedition Selected { get; set; }

        public MainViewModel()
        {
            Expiditions = new List<Expedition>
            {
                new Expedition {  Name = "Персеиды", Mission = "ММП", Latitude = 46.67 },
                 new Expedition {  Name = "Пеftы", Mission = "МnhhП", Latitude = 47 } ,
                  new Expedition {  Name = "Пеtttttы", Mission = "gfg", Latitude = 4 }
            };

            //задаем функцию которую будет выполнять команда
            //команда нужна для того чтобы потом привязать ее к контролам на форме
            BestCommandEver = new DelegateCommand<Expedition>(HelloWorld);
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
        private void HelloWorld(Expedition expidition)
        {
            MessageBox.Show("HelloWorld");
            expidition.Name = "HelloWorld";
        }
    }
}
