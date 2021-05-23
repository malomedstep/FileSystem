using System.IO;

namespace FileSystem
{
    class FileInfoDemo
    {
        public static void Run()
        {

            // System.IO.FileInfo является OOP-like версией System.IO.File
            // FileInfo содержит большинство функций, которые есть в File
            // относятся эти функции к конкретному файлу, а не к файлам "в общем"
            var fi = new FileInfo("file.txt");

            // если файл не существует
            if (!fi.Exists)
            {
                // создаем, записываем 42
                using var fs = fi.OpenWrite();
                fs.WriteByte(42);
            }
            // удаляем
            fi.Delete();

            // остальные функции +- те же, что и в File
        }
    }
}