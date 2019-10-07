using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class FileSystemVisitor
    {
        DirectoryInfo directoryInfo;
        private string path;
        public FileSystemVisitor(string path)
        {
            directoryInfo = new DirectoryInfo(path);
            this.path = path;
        }

        public FileSystemInfo[] GetCatalogsAndFiles(string searchPattern)
        {
            return directoryInfo.GetFileSystemInfos(searchPattern);
        }

    
    }
}
