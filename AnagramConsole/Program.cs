using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = string.Concat(Directory.GetCurrentDirectory(), "\\words.txt");
            var controller = new AnagramController(new AnagramsTextFile(File.ReadLines(filePath).ToArray()));
            Console.WriteLine(controller.GetAnagrams());
            Console.ReadKey();
        }
    }
}