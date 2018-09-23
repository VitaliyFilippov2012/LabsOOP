using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            double proceeds;
            double priceAmount;
            int rounding = 2;
            string _name;
            float _cost;
            Counter.currentCount = 0; //Задаём начальное значение счётчика с закрытым конструктором
            Product milk = new Product(24, "Milka", 324234, 2.123f, "Gomel"); //вызов конструктора с параметрами по умолчанию
            Console.WriteLine(Product.counter);//Статический
            Console.WriteLine("New count: {0}", Counter.currentCount);//Закрытый

            Product fish = new Product(23, "Putasa", 2452431);//Вызов конструктора с параметрами
            Console.WriteLine("New count: {0}", Counter.currentCount);
            Console.WriteLine(Product.counter);
            
            Console.WriteLine(milk.ToString());
            Console.WriteLine(milk.GetType());
            Console.WriteLine(fish.Name);
            Console.WriteLine(fish.Name = "Scymbria");
            Console.WriteLine(fish.Name);
            fish.Proceeds(ref rounding, out proceeds, out priceAmount);
            Console.WriteLine($"Выручка: {proceeds}\nОбщая сумма: {priceAmount}");

            milk.Proceeds(ref rounding, out proceeds, out priceAmount);
            Console.WriteLine($"Выручка: {proceeds}\nОбщая сумма: {priceAmount}");
            Console.WriteLine(milk.Equals(fish));
            Console.WriteLine(milk.GetHashCode());
            var yogurt = new Product(34, "Lask", 2545644232, 1.99f, "Lepel", 1210);
            yogurt.ToString();


            //задания
        


            Product[] arrayProduct = { new Product(24, "Сметана", 32423234, 2.123f, "Gomel"), new Product(34, "Йогурт", 25644232, 1.99f, "Lepel", 1210), new Product(39, "Сметана", 36120895, 1.56f, "Gorodok", 30657), new Product(45, "Кефир", 25114232, 0.99f, "Gorodok", 123),new Product(467, "Йогурт", 89778234, 2.3f, "Polotsk"), new Product(233, "Сметана", 12388534, 2.34f, "Orsha") };
            Console.WriteLine("Введите желаемое наименование");
            _name = Console.ReadLine();
            Console.WriteLine("Введите цену, которую не должны превысить, если пропустить - 0");
            _cost = (float)Convert.ToDouble(Console.ReadLine());
            Product.Info();
            bool c = false;
            bool x = (_cost>0);

            foreach ( Product item in arrayProduct)
            {
                if (x)
                {
                    if ((item.Name == _name) && (item.Price < _cost))
                    {
                        Console.WriteLine(item.ToStr());
                        c = true;
                    }
                }
                else
                {
                    if (item.Name == _name) 
                    {
                        Console.WriteLine(item.ToStr());
                        c = true;
                    }
                }
            }
            if (!c)
            {
                Console.WriteLine("Таких продуктов нет!");
            }
            Console.ReadKey();
        }
    }

   
}
