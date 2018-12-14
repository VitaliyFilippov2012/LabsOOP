using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab16
{
    class Program
    {
        static int[] iArr;
        static void Main(string[] args)
        {
            Task taskEratosfen = new Task(() => Eratosfen.DoEratosfen(89546));
            Console.WriteLine($"Задача выполняется.Состояние: { taskEratosfen.Status} ");
            Stopwatch stopwatch = Stopwatch.StartNew();
            taskEratosfen.Start();
            Task openFile = taskEratosfen.ContinueWith(Pros);
            while (!taskEratosfen.IsCompleted)
            {
                Console.WriteLine($"Задача выполняется.Состояние: { taskEratosfen.Status} ");
                Thread.Sleep(5500);

            }
            if (taskEratosfen.IsCompleted)
            {
                Console.WriteLine($"Задача не выполняется. Состояние: { taskEratosfen.Status}. Прошло времени: {stopwatch.ElapsedMilliseconds} ");
            }
            Console.ReadKey();
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = cancelTokenSource.Token;
            Task taskWithTokenCancel = new Task(() => Pros(cancelToken));

            stopwatch.Restart();
            taskWithTokenCancel.Start();
            if (stopwatch.ElapsedMilliseconds > 10000)
            {
                cancelTokenSource.Cancel();
                if (cancelToken.IsCancellationRequested)
                {
                    Console.WriteLine("Token cancel request");
                }
            }
            taskWithTokenCancel.Wait();
            Console.WriteLine($"Время выполнения {stopwatch.ElapsedMilliseconds}");
            stopwatch.Reset();
            Task<float> t1 = new Task<float>(() => 3.14f * 23);                                                                             //Действия-рандом на своё усмотрение
            Task<int> t2 = new Task<int>(() => 23 * 16 * 5);
            Task<long> t3 = new Task<long>(() => 232333 * 5553);
            t1.Start();
            t2.Start();
            t3.Start();

            Task.WaitAll(t1, t2, t3);//все 3 задачи выполняются в параллельном режиме(асинхронно) и все их возвращаемые значения используются в следующей задаче
            // Запускаем 4 задачу когда завершаттся все 3 предыдущие
            Task<int> t4 = new Task<int>(() => (int)(t3.Result / (t2.Result * t1.Result)));
            t4.Start();
            Console.WriteLine($"Задание 3: {t4.Result}");
            Random random = new Random();
            Func<int, int> f = (a) => a + random.Next(3, 32);  //Делегат, который прибавляет к числу пользователя рандомное число из промежутка 
            Task<int> fun = new Task<int>(() => f(1)); //Делегат выполняется в задаче
            Task<int> fun1 = fun.ContinueWith((a) => f(a.Result)); //При окончании задачи, возвращаемое значение переходит как параметр в делегат сл задачи
            fun.Start();
            Task.WaitAny(fun1);
            Console.WriteLine($"Task1: {fun.Result} task2: {fun1.Result}");

            Task<int> fun11 = new Task<int>(() => f(1));
            fun11.Start();

            while (true)
            {
                if (fun11.GetAwaiter().IsCompleted)
                {
                    new Task(() => Console.WriteLine($"Task1: {fun11.GetAwaiter().GetResult()} Task2: Comleted")).Start();
                    break;
                }

            }

            iArr = new int[1000];
            for (int i = 0; i < 1000; ++i)
            {
                iArr[i] = random.Next(0, 1232);
            }
            stopwatch.Start();
            int elem;
            IEnumerable<int> arr = iArr.Select(n => n);
            Parallel.For(0, 1000, (i) => elem = arr.ElementAt(i) / (2));
            Console.WriteLine($"Parallel For сработал за: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();
            Parallel.ForEach<int>(arr, (n) => elem = n / 2);
            Console.WriteLine($"Parallel Foreach сработал за: {stopwatch.ElapsedMilliseconds}");

            //Quicksort(0, 999);
            //foreach(int i in iArr)
            //{                                               //массив на экран(занимает много места)
            //    Console.Write($" {i}");
            //}
            SmthFunc(1000, 1005);


                                                                // Не разбирайся что выводит на экран здесь, здесь...
            //Task7
            BlockingCollection<int> appliances = new BlockingCollection<int>();
            Thread thpr = new Thread(() => AllTaskProv());
            thpr.Start();
            Thread thcus = new Thread(() => AllTaskCust());
            thcus.Start();
            void AllTaskProv()
            {
                Task.Run(() => Producer(ref appliances, 500, 1));
                Task.Run(() => Producer(ref appliances, 900, 2));
                Task.Run(() => Producer(ref appliances, 200, 3));
                Task.Run(() => Producer(ref appliances, 700, 4));
                Task.Run(() => Producer(ref appliances, 1000, 5));
            }
            void AllTaskCust()
            {
                Task.Run(() => Customer(ref appliances, 1000));
                Task.Run(() => Customer(ref appliances, 1500));
                Task.Run(() => Customer(ref appliances, 3000));
                Task.Run(() => Customer(ref appliances, 500));
                Task.Run(() => Customer(ref appliances, 4000));
                Task.Run(() => Customer(ref appliances, 2334));
                Task.Run(() => Customer(ref appliances, 987));
                Task.Run(() => Customer(ref appliances, 4323));
                Task.Run(() => Customer(ref appliances, 2112));
                Task.Run(() => Customer(ref appliances, 6000));
            }

            Console.ReadKey();
        }

        public static void Pros(Task t)
        {
            Process.Start("notepad.exe", @"E:\Универ\ООП\Лабы\Eratosfen.txt");
        }
        public static void Pros(CancellationToken token)
        {
            Process.Start("notepad.exe", @"E:\Универ\ООП\Лабы\Eratosfen.txt");
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Токен");
                return;
            }
            Console.WriteLine("Id " + Task.CurrentId);
        }

        static int Partition(int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (iArr[i] <= iArr[end])
                {
                    int temp = iArr[marker]; // swap
                    iArr[marker] = iArr[i];
                    iArr[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        public static void Quicksort(int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(start, end);
            Parallel.Invoke(() => Quicksort(start, pivot - 1), () => Quicksort(pivot + 1, end));
        }

        public static async void SmthFunc(int i, int j)
        {
            await Task.Run(() => {
                for (int z = 0; z < 10; z++)
                {
                    Console.WriteLine(z);
                }

            });
            for (int z = j; z > i; z--)
            {
                Console.WriteLine(z);
            }

        }

        public static void Producer(ref BlockingCollection<int> blockingCollection, int timeMs,int id)
        {
            for (int i = 0; i < 5; ++i)
            {
                blockingCollection.Add(id);
                int[] a = blockingCollection.ToArray();
                Console.WriteLine("!!!");
                for (int z = 0; z < a.Length; z++)
                { 
                    Console.WriteLine($" *{a[z]}");
                    
                }
                Console.WriteLine("///\n");
                Console.WriteLine();
                Thread.Sleep(timeMs);
            }
        }

        public static void Customer(ref BlockingCollection<int> blockingCollection, int timeMs)
        {
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine("---");
                if (blockingCollection.Count != 0)
                {
                    foreach(var n in blockingCollection.GetConsumingEnumerable())
                    {
                        Console.WriteLine($" - {n}");
                       
                    }

                }
                Console.WriteLine("///\n");

                Thread.Sleep(timeMs);
            }
        }
    }

}
