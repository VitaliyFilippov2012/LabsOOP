using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Rectangle fig = new Rectangle(12,12);
            Figure recToFig = ConvertToFigure(fig);
            Console.WriteLine(recToFig.NameDecor());
            Console.WriteLine(recToFig.Name());

            Console.WriteLine("_______________________________________");
            Menu menu = new Menu();
            Button menuToButton = ConvertToButton(menu);
            Console.WriteLine(menuToButton.NameDecor());
            Console.WriteLine(menuToButton.Name());
            Console.WriteLine("_______________________________________");


            IDecor[] array = new IDecor[] { new Button("B1"), new Rectangle(100, 100), new Menu(), new Window(), new DecorA() };
            foreach (IDecor item in array)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();


        }

        private static Figure ConvertToFigure(Figure obj)
        {
            if (obj is Rectangle)
            {
                return obj as Figure;
            }
            return null;
        }

        private static Button ConvertToButton(Button obj)
        {
            if (obj is Menu )
            {
                return obj as Button;
            }
            return null;
        }
    }
}
