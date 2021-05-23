using System.IO;

namespace FileSystem
{
    class DirectoryInfoDemo
    {
        public static void Run()
        {
            // System.IO.DirectoryInfo является OOP-like версией System.IO.Directory
            // DirectoryInfo содержит большинство функций, которые есть в Directory

            var di = new DirectoryInfo("dir");

            // если папка существует
            if (di.Exists)
            {
                // удаляем папку рекурсивно - удаляем папку и все содержимое
                di.Delete(true);
            }
        }
    }
}