using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    struct Theme : IDecor
    {
        string name;
        string decor;
        
        public Theme(string n,string d)
        {
            name = n;
            decor = d;
        }

        public string NameDecor()
        {
            return $"Тема - {this.name} и оформление - {this.decor}";
        }

    }

    enum Level
    {
        first,
        second,
        third,
        fourth,
        fifth
    }
}
