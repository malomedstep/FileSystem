using System.IO;

namespace FileSystem
{
    class FileDemo
    {
        public static void Run()
        {
            // System.IO.File содержит только статические методы-обертки над обычными OS-specific функциями для работы с файловой системой
            // касающие только файлов

            // создает файл и возвращает FileStream для записи
            _ = File.Create("file_create.txt");

            // открывает файл и возвращает FileStream для чтения/записи - зависит от режима
            _ = File.Open("file_create.txt", FileMode.Open);

            // проверяет, существует ли указанный файл
            _ = File.Exists("file.txt");

            // File.WriteAllxxx и File.AppendAllxxx используются для быстрой [до]записи разных данных в файл в 1 строку
            File.WriteAllText("write_all.txt", "salam");
            File.AppendAllText("write_all.txt", "salam");

            // File.ReadAllxxx используется для быстрого считывания разных данных в файл в 1 строку
            _ = File.ReadAllText("write_all.txt");

            // удаляет файл
            File.Delete("file.txt");

            // File.Move используется как для перемещения файла, так и для переименования
            File.Move("a.txt", "b.txt");

            // Используются для получения и изменения атрибутов файла
            _ = File.GetAttributes("file.txt");
            File.SetAttributes("file.txt", FileAttributes.Hidden | FileAttributes.ReadOnly);
        }
    }
}