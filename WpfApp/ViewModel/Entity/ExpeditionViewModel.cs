using System.Collections.Generic;

namespace WpfApp.ViewModel.Entity
{
    public class ExpeditionViewModel //: INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Mission { get; set; }

        
        public double Latitude { get; set; }

        public List<DayViewModel> Days { get; set; }

        ////это событие оповещает о том что поле изменилось
        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged([CallerMemberName]/*<- это нужно чтобы propertyName задавалось автоматически 
        //именем свойства из которого была вызвана эта функция*/ string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
