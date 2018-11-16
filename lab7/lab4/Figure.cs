using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    abstract class Figure
    {
        private IDecor _decor;

        public string Decor
        {
            get => _decor.NameDecor();
        }

        public Figure()
        {
            _decor = new DecorA();
        }

        public virtual string Name()
        {
            return "?-?";
        }

        public string NameDecor()
        {
            return "DecorFigure";
        }
    }
}
