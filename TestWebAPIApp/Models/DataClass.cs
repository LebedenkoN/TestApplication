using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebAPIApp.Models
{
    public struct DataStruct
    {
        public System.IO.FileInfo[] files;
        public System.IO.DirectoryInfo[] subDirs;
        public int less10;
        public int beetwen;
        public int more50;
    }
}