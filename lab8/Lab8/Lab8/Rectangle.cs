using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Rectangle : Figure
    {
        string name;

        public Rectangle(string name) : base(name)
        {
            this.name = name;
        }
        new public string Name
        {
            get => name;
            set => name = value;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
