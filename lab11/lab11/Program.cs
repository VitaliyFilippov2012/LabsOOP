using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "Jule", "August", "September", "October", "November", "December" };
            Console.WriteLine("\nOrder Month:");
            IEnumerable<string> orderMonths = from str in months
                                              orderby str
                                              select str;
            foreach(string str in orderMonths)
            {
                Console.WriteLine($"{str}");
            }
            int[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var calendar = months
                .Join(key, w => w.Length, q => q , (w, q) => new
                {
                    id = q,
                    name = w,
                });
            foreach (var item in calendar)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("\nMonth with length < 6: ");
            IEnumerable<string> monthsWithLengthN = from str in months
                                                    where str.Length < 6
                                                    select str;
            foreach (string str in monthsWithLengthN)
            {
                Console.WriteLine($"{str}");
            }
            Console.WriteLine("\nWinter months: ");
            IEnumerable<string> winterMonths = from str in months
                                               where (str.ToLower().StartsWith("j")) || (str.ToLower().StartsWith("f")) || (str.ToLower().StartsWith("d"))
                                               where (str.Length < 9) && (str.Length > 6)
                                               select str;
            foreach (string str in winterMonths)
            {
                Console.WriteLine($"{str}");
            }
            Console.WriteLine("\nSummer months: ");
            IEnumerable<string> summerMonths = from str in months
                                               where (str.ToLower().StartsWith("j")) || (str.ToLower().StartsWith("au"))
                                               where (str.Length < 7) && (str.Length > 3)
                                               select str;
            foreach (string str in summerMonths)
            {
                Console.WriteLine($"{str}");
            }
            Console.WriteLine("\nMonth, which consists u and length <=4 : ");
            IEnumerable<string> cpecialMonths = from str in months
                                               where (str.ToLower().Contains("u"))
                                               where (str.Length <= 4 )
                                               select str;
            foreach (string str in cpecialMonths)
            {
                Console.WriteLine($"{str}");
            }
            List<Product> list = new List<Product>
            {
                new Product(1, "Milk", 122123, 1.99f,"Orsha"),
                new Product(2, "Mazic", 133123, 2.05f, "Brest"),
                new Product(3, "Kepchyp", 144423, 2.10f, "Gomel"),
                new Product(4, "Apple", 146573, 1.55f, "Alecsandria"),
                new Product(5, "Iogurt", 111223, 0.99f,"Orsha"),
                new Product(6, "Orange", 188723, 2.99f, "Gomel"),
                new Product(7, "Tea", 123999, 4.55f,"Bereza"),
                new Product(8, "Coffee", 159223, 5.69f,"Orsha"),
                new Product(9, "Cherry", 122983, 2.15f, "Alecsandria"),
                new Product(10, "Banana", 231667, 1.99f,"Gorodok"),
                new Product(1, "Milk", 122124, 1.99f,"Glubokoe"),
                new Product(2, "Mazic", 133124, 2.05f, "Alecsandria"),
                new Product(3, "Kepchyp", 144424, 2.10f),
                new Product(4, "Apple", 146574, 1.55f, "Gomel"),
                new Product(5, "Iogurt", 111224, 1.99f, "Brest"),
                new Product(6, "Orange", 188724, 2.99f, "Alecsandria"),
                new Product(7, "Tea", 124000, 4.55f),
                new Product(8, "Coffee", 159224, 5.0f, "Brest"),
                new Product(9, "Cherry", 122984, 2.15f,"Orsha"),
                new Product(10, "Banana", 231668, 1.99f, "Gomel"),
                new Product(1, "Milk", 122125, 1.99f,"Orsha"),
                new Product(2, "Mazic", 133125, 2.05f),
                new Product(3, "Kepchyp", 144425, 2.10f, "Alecsandria"),
                new Product(4, "Apple", 146575, 1.55f, "Alecsandria"),
                new Product(5, "Iogurt", 111225, 1.05f, "Brest"),
                new Product(6, "Orange", 188725, 2.99f),
                new Product(7, "Tea", 124001, 4.55f, "Gomel"),
                new Product(8, "Coffee", 159225, 4.99f),
                new Product(9, "Cherry", 122985, 2.15f,"Orsha"),
                new Product(10, "Banana", 231669, 1.99f, "Brest")
            };
            Console.WriteLine($"Coffee");
            IEnumerable<Product> productNameCoffee = from n in list
                                                    where n.Name == "Coffee"
                                                    select n;
            foreach (Product n in productNameCoffee)
            {
                Console.WriteLine($"{ n.ToString()}");
            }

            Console.WriteLine($"Iogurt price < 1.50");
            IEnumerable<Product> productNamePrice = from n in list
                                                    where n.Name == "Iogurt"
                                                    where n.Price < 1.5f
                                                    select n;
            foreach (Product n in productNamePrice)
            {
                Console.WriteLine($"{ n.ToString()}");
            }
            Console.WriteLine($"Count name, with price > 2.30");
            IEnumerable<Product> countNameWithPrice = from n in list
                                         where n.Price < 2.30
                                         select n;
            int count = countNameWithPrice.Count();
            Console.WriteLine($"{count}");
            Console.WriteLine("Order list");
            IEnumerable<Product> llist = list.OrderBy(s => s.Producer)
                .ThenBy(s => s.Name);
            foreach (Product n in llist)
            {
                Console.WriteLine($"{n.ToString()}");
            }
            
            IEnumerable<Product> p = from n in list
                                     orderby n.Price
                                     select n;
            IEnumerable<Product> max = p.Skip(p.Count()-1);
            Console.WriteLine("\nМаксимальный элемент: ");
            foreach(Product n in max)
            {
                Console.WriteLine($"{n.ToString()}");
            }

            IEnumerable<IGrouping<string, Product>> orderList =
                list.Where(n => n.UPC < 140000)
                .Where(n => n.Id < 8)
                .Select(n => n)
                .GroupBy(n => n.Name)
                .OrderBy(n => n.Key.Length);

            foreach (var group in orderList)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ToString()}");
                }
            }
            Console.ReadKey();
        }
    }
}
