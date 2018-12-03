using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            FVLDiskInfo s = new FVLDiskInfo();
            s.ShowAllDriveInfo();
            s.GetFreeSpaceDisk(@"E:\");
            Console.ForegroundColor = ConsoleColor.Cyan;

            FVLFileInfo.GetFileByPath(@"E:\Универ\ООП\Лабы\Новая папка\param.txt");
            Console.ForegroundColor = ConsoleColor.Blue;

            FVLDirInfo.GetDirInfo(@"E:\Универ\ООП");
            Console.ForegroundColor = ConsoleColor.Cyan;

            FVLDirInfo.GetDirInfo(@"E:\Универ\ООП\Лабы");
            FVLFileManager.CreateDir(@"E:\Универ\ООП\Лабы\", "FVLInspect");
            FVLFileManager.CreateTxtFile(@"E:\Универ\ООП\Лабы\FVLInspect\", "fvldirinfo");
            FVLFileManager.CopyFile(@"E:\Универ\ООП\Лабы\FVLInspect\fvldirinfo.txt", null);
            FVLFileManager.RenameFile(@"E:\Универ\ООП\Лабы\FVLInspect\", "fvldirinfo_copyFile.txt", "renameFile.txt");
            FVLFileManager.DeleteFile(@"E:\Универ\ООП\Лабы\FVLInspect\fvldirinfo.txt");
            Console.ForegroundColor = ConsoleColor.Blue;

            FVLFileManager.CreateDir(@"E:\Универ\ООП\Лабы\", "FVLFiles");
            FVLFileManager.CopyFilesWithExpan(@"E:\Универ\ООП\Лабы\Новая папка\", @"E:\Универ\ООП\Лабы\FVLFiles\", ".txt");
            FVLFileManager.MoveDirectory(@"E:\Универ\ООП\Лабы\FVLFiles", @"E:\Универ\ООП\Лабы\FVLInspect\");
            Console.ForegroundColor = ConsoleColor.Cyan;
            //FVLLog.Delete();
            FVLFileManager.ZipDir(@"E:\Универ\ООП\Лабы\Новая папка", @"E:\Универ\ООП\Лабы", "zipArhive");
            FVLFileManager.UnZip(@"E:\Универ\ООП\Лабы\zipArhive.zip", @"E:\Универ\ООП\Лабы\Разархивировал сюда");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            FVLLog.Show(15);
            Console.ForegroundColor = ConsoleColor.Cyan;
            FVLLog.SearchInfo("Create txt file");
            FVLLog.CountLog();
            Console.ReadKey();
        }
    }
}
