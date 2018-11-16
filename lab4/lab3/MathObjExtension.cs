using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    static class MathObjExtension
    {
        public static int HashCode(this String obj)
        {
            return (obj.CountWords.GetHashCode() + obj.CurrentLength.GetHashCode() + obj.Str.GetHashCode());
        }
          
    }
}
