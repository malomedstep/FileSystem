using System.IO;

namespace FileSystem
{
    class DirectoryDemo
    {
        public static void Run()
        {
            // System.IO.Directory содержит только статические методы-обертки над обычными OS-specific функциями для работы с файловой системой
            // касающиеся, в основном, директорий

            // создает директорию и возвращает DirectoryInfo, описывающий эту директорию
            _ = Directory.CreateDirectory("create_directory");

            // возвращает список логических томов - C, D, E и т.д.
            _ = Directory.GetLogicalDrives();

            // а вот теперь начинается интересное:
            // возвращает список директорий по конкретному пути
            _ = Directory.GetDirectories(@"C:\");
            // возвращает список файлов по конкретному пути
            _ = Directory.GetFiles(@"C:\");
            // возвращает список директорий и файлов по конкретному пути
            _ = Directory.GetFileSystemEntries(@"C:\");

            // возвращает путь к текущей директории - рабочей директории, в которой запущена программа
            _ = Directory.GetCurrentDirectory();
        }
    }
}