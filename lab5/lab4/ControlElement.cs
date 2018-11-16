using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    abstract class ControlElement
    {
        abstract public string Name();
       

        private IDecor _decor;

        public string Decor
        {
            get => _decor.NameDecor();
        }

        public ControlElement()
        {
            _decor = new DecorA();
        }
    }
}
