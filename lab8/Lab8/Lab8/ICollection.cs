using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    interface ICollection<T> 
    {
        bool Add(T x);

        void Del();

        void Show();
    }
}
