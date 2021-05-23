using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // читать файлы нужно в том порядке, в каком тут вызываются демки

            // эти демки покрывают пункты [1-10]
            // FileStreamDemo.Run();
            // BinaryReaderWriterDemo.Run();
            // StreamReaderWriterDemo.Run();

            // эти демки покрывают пункт 11
            // FileDemo.Run();
            // DirectoryDemo.Run();
            // FileInfo.Run();
            // DirectoryInfoDemo.Run();

            // эта демка покрывает пункт 12 [в процессе]
            RegexDemo.Run();
        }
    }

    class RegexDemo
    {
        public static void Run()
        {
            // Regex (REGular EXpressions) - регулярные выражения - это синтаксис и движок для поиска подстрок в тексте по сложным паттернам
            // В разных поисковых системах вы, вероятно, видели возможность поиска по маске:
            //  "*.png" - все png картинки
            //  "report_??_2020.xlsx" - все Excel файлы, с названием report_??_2020.xlsx, где вместо ?? могут быть любые 2 символа
            //  "diploma*" - все файлы, начинающиеся на diploma
            // 
            // Однако очень часто таких возможностей не хватает, т.к. нужно выполнять более сложный поиск
            // тут на помощь приходят регулярные выражения
        }
    }
}
