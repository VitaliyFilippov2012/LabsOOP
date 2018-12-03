using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class FVLFileInfo
    {
        private static FileInfo fI;

        public static void GetFileByPath(string path)
        {
            fI = new FileInfo(path);
            FVLLog.AddLog("Get file by path", path);
            if (fI.Exists)
            {
                Console.WriteLine($" - File name: {fI.Name} | Size: {fI.Length} | Time creating: {fI.CreationTime} | Путь: {fI.DirectoryName}");
            }
            else
            {
                Console.WriteLine("File is not exist");
            }
        }

        public static void MoveFileExpansion(string pathFrom, string pathTo, string expan)
        {
            FVLLog.AddLog("Move file from " + pathFrom + " in " + pathTo,null);
            DirectoryInfo dir = new DirectoryInfo(pathFrom);
            FileInfo[] fileInfo = dir.GetFiles();
            foreach (var n in fileInfo)
            {
                if (n.Extension == expan)
                {
                    n.MoveTo(pathTo + n.Name);
                }
            }
        }

        public static bool CreateTxtFile(string name, string path, string info)
        {
            FVLLog.AddLog("Create txt file  " + name + " in " + path, null);
            path += name + ".txt";
            //File.Create(path);
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine(info);
                sw.Close();
            }
            if (File.Exists(path))
            {
                Console.WriteLine("File successfully created");
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Not complete");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }

        }

        public static int FileSize(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return (int)fileInfo.Length;
        }
    }
}
