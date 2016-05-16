using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.ViewModel
{
    public class ExpeditionViewModel : INotifyPropertyChanged
    {
        public string name;

        public int Id { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                //эту функцию надо вызывать везде где изменяем данные свойств
                OnPropertyChanged();
            }
        }

        
        public string Mission { get; set; }

        
        public double Latitude { get; set; }


        public virtual ICollection<DayViewModel> Days { get; set; }

        //это событие оповещает о том что поле изменилось
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]/*<- это нужно чтобы propertyName задавалось автоматически 
        именем свойства из которого была вызвана эта функция*/ string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
