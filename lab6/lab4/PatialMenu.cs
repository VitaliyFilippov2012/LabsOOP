using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    partial class Menu
    {
        int sizeX;
        int sizeY;
        new public int SizeX { get; set; }
        new public int SizeY { get; set; }
        new public string NameDecor()
        {
            return "DecorToMenu";
        }
        public Menu(int _countLevel = 1, int _sizeX = 3, int _sizeY = 5)
        {
            this.countLevel = _countLevel;
            this.sizeX = _sizeX;
            this.sizeY = _sizeY;
        }
        
    }
}
