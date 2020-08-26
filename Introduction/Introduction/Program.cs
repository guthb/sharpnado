using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"hti9599/workspace/";
            ShowLargeFilesWithoutLinq(path);
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            //sort all files largest to smallest
            foreach (FileInfo file in files)
            {
                Console.WriteLine($"{file.Length} : {file.Length}");
            }

            //5 largest files
            for (int i = 0; i < 5; i ++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Length, -20} : {file.Length, 10}");
            }

            // next method
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }

}
