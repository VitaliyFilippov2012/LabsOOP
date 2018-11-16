using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Counter
    {
        private Counter() { }
        public static int currentCount=0;
        public static void IncrementCount()
        {
            ++currentCount;
        }

    }
    class Window : ControlElement, IDecor
    {
        public string NameDecor()
        {
            return "DecorToWindow";
        }
        public Window()
        {
            Counter.IncrementCount();
        }
        public override string Name()
        {
            return "Window";
        }
        public override string ToString()
        {
            return $"{this.Name()}: {Counter.currentCount}";
        }
    }
}
