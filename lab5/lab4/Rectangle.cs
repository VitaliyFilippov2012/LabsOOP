using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    sealed class Rectangle : Figure, IDecor
    {
        int x;
        int y;

        public int X { get; set; }
        public int Y { get; set; }

        public Rectangle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        new public string NameDecor()
        {
            return "FigureDecor";
        }
        public override string Name()
        {
            return "Rectangle";
        }

        public override string ToString()
        {
            return this.Name();
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode()+this.Y.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj is Rectangle;
        }
    }
}
