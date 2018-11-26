using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflector reflector = new Reflector();
            Product product = new Product(2302, "Oranges", 23945621, 2.99f, "Грузия", 1000);
            Class cl = new Class();
            reflector.WriteInfoAboutClassInFile(product.GetType());

            reflector.GetInterface(product.GetType());

            reflector.GetPublicMethod(cl.GetType());

            reflector.GetFieldAndProperty(product.GetType());

            reflector.GetPublicMethod(product.GetType(), "Void");

            reflector.Met(cl.GetType(), "Summer", cl);

            Console.ReadKey();
        }
    }
}
