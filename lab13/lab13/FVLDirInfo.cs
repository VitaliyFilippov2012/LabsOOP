using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class FVLDirInfo
    {
        private static DirectoryInfo dirInfo;

        public static void GetDirInfo(string path)
        {
            dirInfo = new DirectoryInfo(path);
            FVLLog.AddLog("Get dir info", path);
            if (dirInfo.Exists)
            {
                Console.WriteLine($" - Amount files: {dirInfo.GetFiles().Length}");
                Console.WriteLine($" - Time creating: {dirInfo.CreationTime}");
                Console.WriteLine($" - Amount dir: {dirInfo.GetDirectories().Length}");

                foreach (var n in dirInfo.GetDirectories())
                {
                    Console.WriteLine($" *Dir: {n.Name}");
                }
                Console.WriteLine($" - Path: {path}");
            }
            else
            {
                Console.WriteLine("Dir is not exist");
            }
        }

        public static int SizeDir(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            int size = 0;
            foreach (var n in directoryInfo.GetFiles())
            {
                size += (int)n.Length;
            }

            if (directoryInfo.GetDirectories().Length != 0)
            {
                foreach (var n in directoryInfo.GetDirectories())
                    size += SizeDir(n.FullName);
            }
            return size;
        }
    }
}
