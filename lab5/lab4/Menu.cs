using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Menu : Button, IDecor
    {

        new public string NameDecor()
        {
            return "DecorToMenu";
        }
        public Menu():base("Menu"){ }

        public override string Name()
        {
            return "Menu";
        }
        public override string ToString()
        {
            return "Menu";
        }
    }
}
