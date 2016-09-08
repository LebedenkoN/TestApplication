using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebAPIApp.Models;

namespace TestWebAPIApp.Services
{
    public class WalkDirectoryTreeClass
    {
        public static void WalkDirectoryTree(System.IO.DirectoryInfo root, ref DataStruct data)
        {
            data.files = root.GetFiles("*.*");
            data.less10 = 0;
            data.beetwen = 0;
            data.more50 = 0;
            if (data.files != null)
            {
                FileSizes(data.files, ref data.less10, ref data.beetwen, ref data.more50);
            }
            data.subDirs = root.GetDirectories();
            if(data.subDirs != null)
            {
                Stack<System.IO.DirectoryInfo[]> directories = new Stack<System.IO.DirectoryInfo[]>();
                directories.Push(data.subDirs);
                while(directories.Count != 0)
                {
                    System.IO.DirectoryInfo[] subDirs = directories.Pop();
                    foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                    {
                        System.IO.DirectoryInfo[] subDirs2 = dirInfo.GetDirectories();
                        directories.Push(subDirs2);
                        FileSizes(dirInfo.GetFiles("*.*"), ref data.less10, ref data.beetwen, ref data.more50);
                    }
                }
                
            }
        }
        static void FileSizes(System.IO.FileInfo[] files, ref int less10, ref int beetwen, ref int more50)
        {
            foreach (System.IO.FileInfo fi in files)
            {
                if (fi.Length < 1e+7)
                {
                    less10++;
                }
                else
                {
                    if (fi.Length < 5e+7)
                    {
                        beetwen++;
                    }
                    else
                    {
                        more50++;
                    }
                }
            }
        }
    }
}