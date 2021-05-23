using System;
using System.IO;

namespace FileSystem
{
    // Говоря откровенно, Stream - не самый удобный класс. В большинстве случаев нам нужно записывать что угодно, но не байтовые массивы
    // Числа, строки, булеаны, все это сначала нужно конвертировать в байты, затем записывать. При чтении последовательность обратная.
    // Для того, чтобы упростить использование Stream'ов, были созданы классы-обертки. Эти классы можно обернуть вокруг любого Stream,
    // Не только FileStream. Цель этих классов - предоставить удобный интерфейс работы с потоком.
    // В данном примере мы рассмотрим запись и чтение бинарных данных в поток
    // при помощи классов BinaryReader и BinaryWriter
    class BinaryReaderWriterDemo
    {
        private static void WriteFile()
        {
            using var fs = new FileStream("file2.txt", FileMode.Create, FileAccess.Write, FileShare.None);

            // Создаем обертку вокруг FileStream. По сути, BinaryWriter делает под капотом то, что мы делали руками в прошлом примере:
            // принимает некое значение, конвертирует в байты и записывает в буфер
            using var bw = new BinaryWriter(fs);

            var integer = 42;
            var boolean = true;
            var character = 'B';
            var real = 5.71;

            bw.Write(integer);
            bw.Write(boolean);
            bw.Write(character);
            bw.Write(real);

            // Не закрываем ни BinaryWriter ни FileStream, т.к. работает using
            // К слову - при закрытии BinaryWriter автоматически закрывает и Stream, вокруг которого он обернут
            // Чтобы избежать этого поведения, в конструктор BinaryWriter нужно передать параметр leaveOpen = true:
            //     using var bw = new BinaryWriter(fs, Encoding.Default, true);
        }

        private static void ReadFile()
        {
            using var fs = new FileStream("file2.txt", FileMode.Open, FileAccess.Read, FileShare.Read);

            // Создаем такую же обертку, но для чтения
            using var br = new BinaryReader(fs);

            // Важно: считывать данные нужно в том же порядке, в каком они записывались
            var integer = br.ReadInt32();
            var boolean = br.ReadBoolean();
            var character = br.ReadChar();
            var real = br.ReadDouble();

            Console.WriteLine($"Integer:   {integer}");
            Console.WriteLine($"Boolean:   {boolean}");
            Console.WriteLine($"Character: {character}");
            Console.WriteLine($"Real:      {real}");

            // И тут не закрываем ни BinaryWriter ни FileStream, т.к. работает using
        }

        public static void Run()
        {
            WriteFile();
            ReadFile();
        }
    }
}
