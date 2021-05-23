﻿using System;
using System.IO;
using System.Text;

namespace FileSystem
{
    // Stream - главная абстракция стандарной библиотеки .NET для работы с потоками данных

    // Stream - абстрактный класс, определяющий требования ко всем потокам данных

    // Его классы-наследники, такие как FileStream, MemoryStream, NetworkStream и другие
    // используются при работе с потоками из файла, оперативной памяти и сети соответственно

    // В Stream можно записывать байты и байтовые массивы, и читать байты и байтовые массивы

    // При работе с файловой системой через FileStream, как и в С++, информация буферизируется
    // То есть, FileStream считывает с диска сразу блок информации, даже если мы хотим считать 1 байт
    // При записи FileStream накапливает некоторое количество информации, прежде чем записать ее на диск


    class FileStreamDemo
    {
        private static void WriteToFile()
        {
            // Создать и открыть файл file.txt в режиме записи с блокировкой других попыток открыть файл (даже этой программой)
            var fs = new FileStream("file.txt", FileMode.Create, FileAccess.Write, FileShare.None);

            // Будем это записывать в файл
            var text = "Hello, FileSystem!";

            // Так как все Stream'ы работают только с байтами или байтовыми массивами,
            // для начала нужно сконвертировать текст в байты
            var bytes = Encoding.Default.GetBytes(text);

            // Записываем байты в файл. Строго говоря - байты в файл пока еще не пишутся.
            // Они записываются в буфер в оперативной памяти, а запись в сам файл будет выполнена дальше
            fs.Write(bytes);

            // FileStream.Flush записывает содержимое своего буфера в файл и очищает буфер.
            // Очищать буфер не обязательно, если мы собираемся закрывать файл - в таком случае очистка буфера произойдет автоматически
            fs.Flush();

            // Закрываем файл и "отпускаем" его - теперь его могут открыть другие программы
            fs.Close();
        }

        private static void ReadFromFile()
        {
            // Открываем созданный нами файл в режиме чтения, разрешаем другим его открывать на чтение
            // Для примера используем using для автоматического закрытия файла
            // Вообще, использовать using при работе с файлами рекомендуется всегда
            // ели нет веских оснований этого не делать
            using var fs = new FileStream("file.txt", FileMode.Open, FileAccess.Read, FileShare.Read);

            // В случае с FileStream, длину потока (размер файла) мы можем узнать из свойства Length:
            //     var bytes = new byte[fs.Length];

            // Но не каждый Stream может предоставить такую информацию.
            // В случае с, например, NetworkStream, Length нам уже никак не поможет.
            // Поэтому создаем массив некоторого размера "с запасом"
            var bytes = new byte[4096];

            // FileStream.Read считывает данные из файла, записывает в массив bytes и возвращает количество записанных байт
            var len = fs.Read(bytes, 0, bytes.Length);

            // Преобразовываем байты в строку
            // Если не указать len, Encoding попытается сконвертировать в строку весь массив bytes
            var str = Encoding.Default.GetString(bytes, 0, len);

            Console.WriteLine(str);

            // файл вручную не закрываем, срабатывает using
        }

        public static void Run()
        {
            WriteToFile();
            ReadFromFile();
        }
    }
}
