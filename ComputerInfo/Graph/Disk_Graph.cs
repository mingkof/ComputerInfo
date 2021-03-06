﻿using System;
using GChartLib;
using MetroSuite;
using System.IO;
using ComputerInfo.WMI;

namespace ComputerInfo.Graph
{
    class Disk_Graph
    {

        public static void RefreshGraph(GCircularProgress[] Progresslist, MetroLabel[] Labellist)
        {
            Disk.Refresh();
            int i = 0;
            foreach(DriveInfo drive in Disk.DISK_Volumes)
            {
                if (i >= Disk.GetVolumeCount)
                    break;
                Progresslist[i].Value = (Int32)(((drive.TotalSize - drive.TotalFreeSpace) / (Double)drive.TotalSize) * 100);
                Labellist[i*3 + 2].Text = String.Format("{0:F2} GB", drive.TotalFreeSpace / 1024f / 1024f / 1024f);
                i++;
            }
        }

    }
}
