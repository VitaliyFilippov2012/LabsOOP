using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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
                // Исключение: неожидаемое значение
                b2.SizeX = 10;
                Container container = new Container(win1, m11, m12, b2, m21, m13, b1);
                Debug.Assert(container != null, "Values array cannot be null");

                container.Show();
                container.DeleteElement(5);
                container.Show();
                //Исключение: некорректный индекс
                container.DeleteElement(10);
                container.Show();

                Controller.FindMenuBylevel(container, 2);
                container.AddElement(m22);
                container.Show();

                Controller.FindAllButton(container);
            }
            catch (IndexOutOfDiapException indEx) //Удаление
            {
                Console.WriteLine(indEx.ToString());
                Console.WriteLine(indEx.Data);
                Console.WriteLine(indEx.TargetSite);
                Console.WriteLine(indEx.StackTrace);
            }
            catch (DivideByZeroException zerEx)
            {
                Console.WriteLine(zerEx.ToString());
                Console.WriteLine(zerEx.Data);
                Console.WriteLine(zerEx.TargetSite);
                Console.WriteLine(zerEx.StackTrace);
            }
            catch (MyException myEx) 
            {
                Console.WriteLine(myEx.ToString());
                Console.WriteLine(myEx.Data);
                Console.WriteLine(myEx.TargetSite);
                Console.WriteLine(myEx.StackTrace);
            }
            catch (NegativeExceptions negEx) // Ширина\высота
            {
                Console.WriteLine(negEx.ToString());
                Console.WriteLine(negEx.Data);
                Console.WriteLine(negEx.TargetSite);
                Console.WriteLine(negEx.StackTrace);

            }
            catch// <=
            {
                Console.WriteLine("Неопознанное исключение");
            }
            finally
            {
                Console.WriteLine("The End");
            }
            int i = 1;
            // int i = 0;
            

            Console.ReadKey();
        }

      
    }
}
