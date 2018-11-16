using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class DecorA : IDecor
    {
        public string NameDecor()
        {
            return "DecorNew";
        }

        public override string ToString()
        {
            return "Decor";
        }
    }
}
