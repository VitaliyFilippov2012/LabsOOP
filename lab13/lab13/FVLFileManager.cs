using System;
using System.IO;
using System.IO.Compression;

namespace lab13
{
    class FVLFileManager
    {
        public static void CreateDir(string path, string name)
        {
            FVLLog.AddLog("Create dir", path);
            path += name;
            if (Directory.CreateDirectory(path).Exists)
            {
                Console.WriteLine("We create new direct");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: direction was not created");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            
        }

        public static void CreateTxtFile(string path, string name, string info = "Filippov Vitaliy 2-8")
        {
            FVLLog.AddLog("Create text ", path);
            
            if (FVLFileInfo.CreateTxtFile(name, path, info))
            {
                Console.WriteLine("We create new file");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: file was not created");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void CopyFile(string pathFrom , string pathIn)
        {
            FVLLog.AddLog("Copy file ", pathFrom);
            if (pathIn == null)
            {
                pathIn = pathFrom.Remove(pathFrom.Length - 4, 4);
                pathIn += "_copyFile";
                pathIn += pathFrom.Substring(pathFrom.Length - 4);

            }
            File.Copy(pathFrom, pathIn);
            if (!File.Exists(pathIn))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: file was not copied");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void CopyFilesWithExpan(string pathFrom, string pathIn, string expan)
        {
            FVLLog.AddLog("Copy files ", pathFrom);
            if (pathIn != null)
            {
                DirectoryInfo fileInfo = new DirectoryInfo(pathFrom);
                foreach(var n in fileInfo.GetFiles())
                {
                    if (n.Name.Contains(expan))
                    {
                        CopyFile(pathFrom + n.Name, pathIn + n.Name);
                    }
                }
            }
        }

        public static void RenameFile(string path,string name, string newName)
        {
            FVLLog.AddLog("Rename file ", path);
            CopyFile(path + name, path + newName);
            File.Delete(path + name);
            if ((File.Exists(path + name)) || !(File.Exists(path + newName)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: file was not renamed");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void RemoveFile(string path)
        {
            FVLLog.AddLog("Remove file", path);
            File.Delete(path);
            if (File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: file was not removed");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void MoveDirectory(string pathFrom, string pathIn)
        {
            FVLLog.AddLog($"Move direct from {pathFrom} in {pathIn}", null);
            pathIn += pathFrom.Substring(pathFrom.LastIndexOf(@"\")+1) + @"\";
            CreateDir(@"E:\Универ\ООП\Лабы\FVLInspect\",null);
            Directory.Move(pathFrom, pathIn);
            if (Directory.Exists(pathFrom))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: file was not moved");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void DeleteFile(string path)
        {
            FVLLog.AddLog("Delete file ", path);
            File.Delete(path);
            if (File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error: file was not deleted");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void ZipDir(string path,string pathIn,string name)
        {
            FVLLog.AddLog("Compression", null);
            pathIn = pathIn + @"\" + name + ".zip";
            try
            {
            ZipFile.CreateFromDirectory(path, pathIn);
            Console.WriteLine($"Size directory: {FVLDirInfo.SizeDir(path)}. Size of archive: {FVLFileInfo.FileSize(pathIn)}");
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" - Error: {e.Message}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
           
        }

        public static void UnZip(string path, string pathIn)
        {
            FVLLog.AddLog("Unzipped", path);
            try
            {
                ZipFile.ExtractToDirectory(path, pathIn);
                Console.WriteLine($"Unzipped successfully");

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" - Error: {e.Message}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
