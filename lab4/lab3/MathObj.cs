using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    static class MathObj
    {
        public static int LengthDifference(String obj1, String obj2)
        {
            return obj1.CurrentLength - obj2.CurrentLength;
        }

        public static void Null(String obj)
        {
            obj.Str = "";
            obj.CountWords = 0;
            obj.CurrentLength = 0;
        }

        public static int WordsDifference(String obj1, String obj2)
        {
            return obj1.CountWords - obj2.CountWords;
        }
    }
}
