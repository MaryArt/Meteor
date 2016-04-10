using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Model
{
    public class ClassTest // как viewmodel  нужен только для представления данных
    {
        public ClassTest()
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

        public List<Expedition> Expiditions { get; set; }

        public Expedition Selected { get; set; }

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
