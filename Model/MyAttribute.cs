using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DisplayableAttribute : Attribute // создаём собственный атрибут наследуясь от стандартного класса
    {
        public bool Displayed { get; set; } // создаём своё свойство которое будет содержать атрибут
                                            // можно описать несколько свойств но для примера создаётся только одно

        public DisplayableAttribute(bool displayed)
        {
            Displayed = displayed;
        }
    }
}
