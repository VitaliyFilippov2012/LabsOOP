using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    [Serializable]
    public class Window : IDecor
    {
        public string nameDec;
        public string nameWin;
        public Window()
        {

        }
        public Window(string nameDec = "Decor for window", string nameWin = "New window")
        {
            this.nameDec = nameDec;
            this.nameWin = nameWin;
        }
        public string NameDec { get; set; }

        public string NameWin { get; set; }

        public override string ToString()
        {
            return $"Window: {nameWin} with decor: {nameDec}";
        }
    }
}
