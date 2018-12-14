using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Reflection;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Process[] process = Process.GetProcesses();
                using (StreamWriter sw = new StreamWriter(@"E:\Универ\ООП\Лабы\Process.txt", false, Encoding.UTF8))
                {
                    foreach (Process pr in process)
                    {
                        Console.WriteLine($" - Имя процесса: {pr.ProcessName} ID-процесса: {pr.Id} Приоритет: {pr.BasePriority}\n");
                        sw.WriteLine($" - Имя процесса: {pr.ProcessName} ID-процесса: {pr.Id} Приоритет: {pr.BasePriority}\n");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            //Task2
            {
                var thisAppDomain = Thread.GetDomain();
                using (StreamWriter sw = new StreamWriter(@"E:\Универ\ООП\Лабы\Domen.txt", false, Encoding.UTF8))
                {
                    Console.Write($" - Name: {thisAppDomain.FriendlyName} Setup Information: {thisAppDomain.SetupInformation} Assemblies: ");
                    sw.Write($" - Name: {thisAppDomain.FriendlyName} Setup Information: {thisAppDomain.SetupInformation} Assemblies: ");
                    foreach (Assembly n in thisAppDomain.GetAssemblies())
                    {
                        Console.Write($" {n.FullName.ToString()} ");
                        sw.WriteLine($" {n.FullName.ToString()} ");
                    }
                    sw.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Blue;

            }
            //Task3
            { 
                Thread thread = new Thread(new ParameterizedThreadStart(Numbers));
                thread.Start(13);
                ThreadInfo(thread);
                thread.Suspend();
                ThreadInfo(thread);
                thread.Resume();
                ThreadInfo(thread);

                void Numbers(object num)
                {
                    int number = (int)num;
                    using (StreamWriter sw = new StreamWriter(@"E:\Универ\ООП\Лабы\Numbers.txt", false, Encoding.UTF8))
                    {
                        for (int i = 0; i < number; i++)
                        {
                            sw.WriteLine(i);
                            Console.WriteLine(i);
                            Thread.Sleep(500);
                        }
                    }
                }
                void ThreadInfo(Thread th)
                {
                    Console.WriteLine("\n--------------------");
                    Console.WriteLine("Its state: " + th.ThreadState);
                    Console.WriteLine("Its priority: " + th.Priority);
                    Thread.Sleep(100);
                    Console.WriteLine("Its ID: " + th.ManagedThreadId);
                    Console.WriteLine("---------------------");
                    Thread.Sleep(1000);
                }
            }
            //Task4
            {
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Cyan;
                DoItInOrder();
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Blue;
                DoItOneByOne();
            }

            //Task5
            {
                Console.ReadKey();
                TimerCallback timerCallback = new TimerCallback(func);

                Timer timer = new Timer(timerCallback, null, 0, 1000);

                Thread.Sleep(5000);
                
                void func(object obj)
                {
                    Console.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
                }
            }
            Console.ReadKey();
        }



        public static void DoItInOrder()
        {
            File.Delete(@"E:\Универ\ООП\Лабы\InOrder.txt");
            Object locker = new Object();
            
            Thread oddTh = new Thread(new ThreadStart(PrintOdd));
            Thread evenTh = new Thread(new ThreadStart(PrintEven));
            oddTh.Start();
            evenTh.Start();
            void PrintOdd()
            {
                lock (locker)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i);
                            WriteInFile(i);
                            Thread.Sleep(250);
                        }
                    }
                }
            }

            void PrintEven()
            {
                lock (locker)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i);
                            WriteInFile(i);
                            Thread.Sleep(500);
                        }
                    }
                }
            }
            void WriteInFile(int n)
            {
                StreamWriter sw = new StreamWriter(@"E:\Универ\ООП\Лабы\InOrder.txt",true, Encoding.UTF8);
                sw.WriteLine(n);
                sw.Close();
            }
        }

        public static void DoItOneByOne()
        {
            Mutex mutex = new Mutex();
            File.Delete(@"E:\Универ\ООП\Лабы\OneByOne.txt");
            Thread oddTh = new Thread(new ThreadStart(PrintOdd));
            Thread evenTh = new Thread(new ThreadStart(PrintEven));
            evenTh.Start();
            oddTh.Start();
            

            void PrintOdd()
            {
                for (int i = 0; i < 20; i++)
                {
                    mutex.WaitOne();
                    if (i % 2 != 0)
                    {
                        Console.WriteLine(i);
                        WriteInFile(i);
                        Thread.Sleep(250);
                    }
                    mutex.ReleaseMutex();
                }  
            }

            void PrintEven()
            {
                for (int i = 0; i < 20; i++)
                {
                    mutex.WaitOne();
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                        WriteInFile(i);
                        Thread.Sleep(500);
                    }
                    mutex.ReleaseMutex();
                }  
            }

            void WriteInFile(int n)
            {
                StreamWriter sw = new StreamWriter(@"E:\Универ\ООП\Лабы\OneByOne.txt", true, Encoding.UTF8);
                sw.WriteLine(n);
                sw.Close();
            }
        }
    }
}
