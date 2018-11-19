using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Rectangle: Figure
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
        public override bool Equals(object obj)
        {
            return obj is Rectangle;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
