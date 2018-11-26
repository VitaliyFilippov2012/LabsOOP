using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    interface IReflector
    {
        void WriteInfoAboutClassInFile(Type typeobj);

        void GetPublicMethod(Type typeobj);

        void GetFieldAndProperty(Type typeobj);

        void GetInterface(Type typeobj);

        void GetPublicMethod(Type typeobj, string typeMet);

        void Met(Type typeobj, string method, Object obj);
    }
}
