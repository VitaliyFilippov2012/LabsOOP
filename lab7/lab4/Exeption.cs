using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class MyException: Exception 
    {
        public MyException(string message): base(message) { }

        public override string ToString()
        {
            return $"Exception: {this.Message}";
        }
        public override IDictionary Data => base.Data;
        public override string StackTrace => base.StackTrace;
    }

    class IndexOutOfDiapException: Exception //Удаление по позиции
    {
        public IndexOutOfDiapException(string message): base(message) { }

        public override string ToString()
        {
            return $"Exception: {this.Message}";
        }
        public override IDictionary Data => base.Data;
        public override string StackTrace => base.StackTrace;


    }

    class NegativeExceptions: Exception
    {
        public NegativeExceptions(string message) : base(message) { }

        public override string ToString()
        {
            return $"Exception: {this.Message}";
        }
        public override IDictionary Data => base.Data;
        public override string StackTrace => base.StackTrace;
    }
}
