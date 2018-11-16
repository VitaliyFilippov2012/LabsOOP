using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    partial class Menu : Button, IDecor
    {
        private int countLevel = 0;

        public int CountLevel
        {
          get => countLevel;
        }
        public override string Name()
        {
            return "Menu";
        }
        public override string ToString()
        {
            return $"Menu {this.CountLevel}";
        }
        
        public Menu CreateNewLevelMenu()
        {
            return new Menu(countLevel+1);
        }
       
    }
}
