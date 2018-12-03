using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class FVLLog
    {
        public static void AddLog(string method, string path)
        {
            string pathHistory = @"E:\Универ\ООП\Лабы\History\FVLlogfile.txt";
            try
            {
                //FileStream fileStream = File.Open(pathHistory, FileMode.OpenOrCreate, FileAccess.Write);
                //{fileStream
                using (StreamWriter sw = new StreamWriter(pathHistory, true, Encoding.UTF8))
                {
                    if (path == null)
                    {
                        sw.WriteLine($"*{DateTime.Now}* Method: {method}");
                    }
                    else
                    {
                        sw.WriteLine($"*{DateTime.Now}* Method: {method} . Path: {path}");
                    }
                }
                    //fileStream.Close();

                //}
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: " + e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        //public static void AddLog(IEnumerable<string> lines)
        //{
        //    string pathHistory = @"E:\Универ\ООП\Лабы\History\FVLlogfile.txt";
        //    try
        //    {
        //        FileStream fileStream = File.Open(pathHistory, FileMode.Create, FileAccess.Write);
        //        {
        //            using (StreamWriter sw = new StreamWriter(fileStream))
        //            {
        //                foreach(var n in lines)
        //                {
        //                    sw.WriteLine(n);
        //                }
        //            }
        //            fileStream.Close();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine(" - Error: " + e.Message);
        //        Console.ForegroundColor = ConsoleColor.Gray;
        //    }
        //}
        public static IEnumerable<string> GetLog()
        {
            //string pathHistory = @"E:\Универ\ООП\Лабы\History\FVLlogfile.txt";

            //IEnumerable<string> lines = File.ReadLines(@"E:\Универ\ООП\Лабы\History\FVLlogfile.txt");
            //AddLog(lines);
            //return lines;
            return File.ReadLines(@"E:\Универ\ООП\Лабы\History\FVLlogfile.txt");
            //FileStream fileStream = File.Open(pathHistory, FileMode.Open, FileAccess.Read);
            //{
            //    IEnumerable<string> lines;
            //    using (StreamReader sw = new StreamReader(fileStream))
            //    {
                    
            //    }
            //    fileStream.Close();

            //}
        }

        public static void SearchInfo(string keyWord)
        {
            AddLog($"Searh with key word - {keyWord}",null);
            try
            {
                IEnumerable<string> listHistory = GetLog();
                IEnumerable<string> listStr = listHistory.Where(n => n.Contains(keyWord));
                if (listStr != null)
                {
                    foreach(var n in listStr)
                    {
                        Console.WriteLine(n);
                    }
                }
                else
                {
                    Console.WriteLine($"No info with key word - {keyWord}");
                }
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: " + e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void Show()
        {
            FVLLog.AddLog("Show history" , null);
            IEnumerable<string> z = GetLog();
            foreach (string n in z)
            {
                Console.WriteLine($"{n}");
            }
        }
        public static void Show(int n)
        {
            FVLLog.AddLog($"Show first {n} linis in history", null);

            IEnumerable<string> z = GetLog().Take(n);
            foreach (string i in z)
            {
                Console.WriteLine($"{i}");
            }
        }

        public static void CountLog()
        {
            FVLLog.AddLog("Show count lines in history", null);

            Console.WriteLine($"Count lines in history: {GetLog().Count()}");
        }

        public static void Delete()
        {
            FVLLog.AddLog("Delete part of history", null);
            IEnumerable<string> log = FVLLog.GetLog();
            string pathHistory = @"E:\Универ\ООП\Лабы\History\FVLlogfile.txt";
            string day = DateTime.Today.ToString().Substring(0, 10);
            
            
            IEnumerable<string> ind = log.SkipWhile(n => !n.Contains(day));
            try
            {
                using (FileStream fileStream = File.Open(pathHistory, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fileStream))
                    {
                        foreach (string n in ind)
                        {
                            Console.WriteLine($"{n}");
                            sw.WriteLine($"{n}");
                        }
                    }
                    fileStream.Close();
                }
                
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: " + e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
