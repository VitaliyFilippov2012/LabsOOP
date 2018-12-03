using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class FVLDiskInfo
    {
        private DriveInfo[] driveInfo;

        public FVLDiskInfo() => driveInfo = DriveInfo.GetDrives();

        public void ShowAllDriveInfo()
        {
            FVLLog.AddLog("Show All Driver", null);
            foreach(var n in driveInfo)
            {
                try
                {
                    Console.WriteLine($" - Disk: {n.Name} File system: {n.DriveFormat} Metka: {n.VolumeLabel} Size: {n.TotalSize}");
                }
                catch
                {

                }
            }
        }

        public void GetFreeSpaceDisk(string namedisk)
        {
            FVLLog.AddLog("Get free space disk", namedisk);
            foreach(var n in driveInfo)
            {
                if (namedisk == n.Name)
                {
                    Console.WriteLine("Free space: "+n.TotalFreeSpace);
                }
            }
        }

    }
}
