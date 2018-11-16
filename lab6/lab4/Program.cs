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
            Window win1 = new Window();
            Console.WriteLine($"Свободная площадь в окне: {win1.FreeSquare}"); //Новый уровень вложенности меню создаётся поверх предыдущего меню(не тратиться площадь)
            Menu m11 = win1.CreateMenu();
            Console.WriteLine($"Свободная площадь в окне: {win1.FreeSquare}"); 
            Menu m12 = m11.CreateNewLevelMenu();
            Console.WriteLine($"Свободная площадь в окне: {win1.FreeSquare}");
            Menu m21 = win1.CreateMenu();
            Console.WriteLine($"Свободная площадь в окне: {win1.FreeSquare}");
            Menu m13 = m12.CreateNewLevelMenu();
            Button b1 = win1.CreateButton();
            Console.WriteLine($"Свободная площадь в окне: {win1.FreeSquare}");
            Button b2 = win1.CreateButton();
            Console.WriteLine($"Свободная площадь в окне: {win1.FreeSquare}");
            Console.WriteLine($"{m11.CountLevel}");
            Console.WriteLine($"{m12.CountLevel}");
            Console.WriteLine($"{m21.CountLevel}");
            Console.WriteLine($"{m13.CountLevel}");
            Menu m22 = win1.CreateMenu();

            Container container = new Container(win1 , m11 , m12 ,b2, m21 , m13 , b1);
            container.Show();
            container.DeleteElement(5);
            container.Show();
            Controller.FindMenuBylevel(container, 2);
            container.AddElement(m22);
            container.Show();
            Controller.FindAllButton(container);
            Console.ReadKey();


        }

      
    }
}
