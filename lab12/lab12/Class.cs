using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class Class
    {
        const int sum = 54;

        public void Summer(int s)
        {
            int x = sum + s;
            Console.WriteLine($"Метод вызвали и параметры прочитали из файла полученный ответ: {x}");
        }

        void Prois(int s)
        {
            int x = sum*s;
            Console.WriteLine($"Метод вызвали и параметры прочитали из файла полученный ответ: {x}");
        }

    }
}
