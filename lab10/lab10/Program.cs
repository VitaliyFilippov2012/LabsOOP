using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"1. a {new String('-', 15)}");
            System.Collections.ArrayList array = new System.Collections.ArrayList();
            Random random = new Random();
            for (int i = 0; i < 5; ++i)
            {
                array.Add(random.Next(0,1000));
            }
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"1. b {new String('-', 15)}");
            array.Add("string");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"1. c {new String('-', 15)}");
            array.Add(new Student());
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"1. d {new String('-', 15)}");
            array.Remove(3);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"1. e {new String('-', 15)}");
            Console.WriteLine("ArrayList:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"1. f {new String('-', 15)}");
            Console.WriteLine($"Содержит в коллекции элемент 'string' в позиции:{array.IndexOf("string")}");
            Console.WriteLine($"2. a {new String('-', 15)}");
            SortedList<float, float> sortedList = new SortedList<float, float>()
            {
                [1.0f] = 1.3f,
                [3.0f] = 2.8f,
                [9.0f] = 9.4f,
                [5.0f] = 5.3f,
                [11.0f] = 11.1f,
                [13.0f] = 13.8f

            };

            foreach (var key in sortedList.Keys)
            {
                Console.WriteLine($"{key} : {sortedList[key]}");
            }
            Console.WriteLine($"2. b {new String('-', 15)}");
            Console.WriteLine("Введите количество удаляемых элементов со 2 позиции");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                sortedList.RemoveAt(2);
            }
            foreach (var key in sortedList.Keys)
            {
                Console.WriteLine($"{key} : {sortedList[key]}");
            }
            Console.WriteLine($"2. с {new String('-', 15)}");
            sortedList.Add(21.0f, 21.4f);
            foreach (var key in sortedList.Keys)
            {
                Console.WriteLine($"{key} : {sortedList[key]}");
            }
            Console.WriteLine($"2. d {new String('-', 15)}");
            Stack<float> stack = new Stack<float>();
            foreach (var item in sortedList.Values)
            {
                stack.Push(item);
            }
            Console.WriteLine($"2. e {new String('-', 15)}");
            foreach (var item in sortedList.Values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"2. f {new String('-', 15)}");
            Console.WriteLine($"Содержит в коллекции элемент '2.8' в позиции:{IndexOf(stack, 2.8f)}");
            Console.WriteLine($"3. a {new String('-', 15)}");
            SortedList<float, Rectangle> sortedList2 = new SortedList<float, Rectangle>()
            {
                [1.0f] = new Rectangle("Квадрат"),
                [2.0f] = new Rectangle("Шестиугольник"),
                [3.0f] = new Rectangle("Пятиугольник"),
                [4.0f] = new Rectangle("Круг")
            };
            foreach (var key in sortedList2.Keys)
            {
                Console.WriteLine($"{key} : {sortedList2[key]}");
            }
            Console.WriteLine($"3. b {new String('-', 15)}");
            Console.WriteLine("Введите количество удаляемых элементов со 2 позиции");
            count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                sortedList2.RemoveAt(2);
            }
            foreach (var key in sortedList2.Keys)
            {
                Console.WriteLine($"{key} : {sortedList2[key]}");
            }
            Console.WriteLine($"3. с {new String('-', 15)}");
            sortedList2.Add(5.0f, new Rectangle("Двадцатишестиугольник"));
            foreach (var key in sortedList2.Keys)
            {
                Console.WriteLine($"{key} : {sortedList2[key]}");
            }
            Console.WriteLine($"3. d {new String('-', 15)}");
            Stack<Rectangle> stack2 = new Stack<Rectangle>();
            foreach (var item in sortedList2.Values)
            {
                stack2.Push(item);
            }
            Console.WriteLine($"3. e {new String('-', 15)}");
            foreach (var item in sortedList2.Values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"3. f {new String('-', 15)}");
            Console.WriteLine($"Элемент Rectangle находится в коллекции:{IndexOf(stack2, new Rectangle("Шестиугольник"))}");
            var observCollection = new ObservableCollection<Figure>();
            observCollection.CollectionChanged += ChangedCollection;
            observCollection.Add(new Figure("Rectangle"));
            observCollection.RemoveAt(0);
            Console.ReadKey();
        }

        public static int IndexOf(Stack<float> stack, float number)
        {
            int pos = 0;
            if (!stack.Contains(number))
            {
                return 0;
            }
            for (int i = 0; i < stack.Count; ++i)
            {
                if (stack.ElementAt(i) == number)
                    pos = i++;
                break;
            }
            return pos;
        }

        public static int IndexOf(Stack<Rectangle> stack, Figure obj)
        {
            int pos = 0;
            for (int i = 0; i < stack.Count; ++i)
            {
                if (stack.ElementAt(i).Name == obj.Name)
                {
                    pos = i++;
                    break;
                }
                    
                
            }
            return pos;
        }


        public static void ChangedCollection(Object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection has been changed");
        }
    }

    
}
