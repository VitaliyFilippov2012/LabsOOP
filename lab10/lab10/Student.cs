﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Student
    {
        string name;
        public Student()
        {
            this.name = "Student";
        }

        public override string ToString()
        {
            return $"Класc {name}";
        }
    }
}
