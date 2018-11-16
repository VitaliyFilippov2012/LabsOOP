using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String<int> iarr = new String<int>("First",1,2,3,4);
                iarr.Add(5);
                iarr.Add(5);
                iarr.Del();
                iarr.Add(55);
                iarr.Show();
                String<int> iarr2 = new String<int>("Second",6,7,8);
                iarr2.Add(9);
                iarr2.Add(10);
                iarr2.Add(16);
                iarr2.Del();
                iarr2.Add(55);
                iarr2.Show();
                String<Figure> sfig = new String<Figure>("Class",new Figure("Null"));
                sfig.Add(new Figure("One"));
                sfig.Add(new Figure("Two"));
                sfig.Add(new Rectangle("Theard"));
                sfig.Write(3);
                sfig.Del();
                sfig.Show();
                sfig.Read();
                new Exception();
            }
            catch
            {
                
            }
            finally
            {
                Console.WriteLine("The End");
            }
            Console.ReadKey();
        }
    }
}
