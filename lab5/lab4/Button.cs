using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Button : ControlElement, IDecor
    {
        string nameOfButton;
        public Button()
        {
            nameOfButton = "BV";
        }

        public string NameDecor()
        {
            return "DecorToButton";
        }
        public string NameOfButton
        {
            get => nameOfButton;
            set => nameOfButton = value;
        }
        
        public Button(string name)
        {
            this.nameOfButton = name;
        }

        public override string Name()
        {
            return "Button";
        }

        public override string ToString()
        {
            return $"{this.Name()}: {this.NameOfButton}";
        }
    }
}
