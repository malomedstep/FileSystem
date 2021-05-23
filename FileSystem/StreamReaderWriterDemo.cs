using System;
using System.IO;

namespace FileSystem
{
    // BinaryWriter и BinaryReader намного удобнее голого Stream, когда нам нужно считывать не байты и не байтовые массивы
    // Но минусом этих классов является то, что они записывают данные в поток в таком виде, в каком они хранятся в памяти
    // А это означает, что если мы запишем число 42 через BinaryWriter - в файле мы увидим не 42, а символы, соответствующие кодам [0, 0, 0, 42]
    // Ведь BinaryWriter сначала конвертирует число 42 в байты (int занимает 4 байта), после чего записывает эти байты в буфер

    // Если же нам нужно записывать данные так, чтобы они сохраняли читабельность в файле - нам нужны другие обертки:
    // StreamWriter и StreamReader - обертки над Stream, которые позволяют записывать текстовые данные в поток
    class StreamReaderWriterDemo
    {
        private static void WriteFile()
        {
            using var fs = new FileStream("file2.txt", FileMode.Create, FileAccess.Write, FileShare.None);

            // По сути StreamWriter принимает любое значение, конвертирует его в строку, строку в байты, а байты записывает в поток
            using var sw = new StreamWriter(fs);

            var integer = 42;
            var boolean = true;
            var character = 'B';
            var real = 5.71;

            sw.WriteLine(integer);
            sw.WriteLine(boolean);
            sw.WriteLine(character);
            sw.WriteLine(real);

            // Возможно, методы Write и WriteLine вам кажутся знакомыми. И это не удивительно:
            // Console.Write и Console.WriteLine делают с файлом стандартного вывода (stdout) то,
            // что StreamWriter.Write и StreamWriter.WriteLine делают со Stream

            // Да, снова работает using, ничего не закрываем
        }

        private static void ReadFile()
        {
            using var fs = new FileStream("file2.txt", FileMode.Open, FileAccess.Read, FileShare.Read);

            // Создаем такую же обертку, но для чтения
            using var sr = new StreamReader(fs);

            // Важно: StreamReader умеет считывать только символы и строки
            // кастинг производить нужно вручную
            // Снова что-то напоминает, да?
            // Console.Read, Console.WriteLine, мы смотрим на вас
            var integer = int.Parse(sr.ReadLine());
            var boolean = bool.Parse(sr.ReadLine());
            var character = char.Parse(sr.ReadLine());
            var real = double.Parse(sr.ReadLine());

            // Вообще, вместо xxx.Parse лучше использовать xxx.TryParse, для более эффективного отлавливания ошибочного ввода
            // но в данном случае мы точно знаем, что в файле, поэтому вызываем Parse

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
