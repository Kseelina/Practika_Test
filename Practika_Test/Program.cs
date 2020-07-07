using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string testFolder = @"C:\Users\Brave\Documents\Visual Studio 2019\projects\C#\Practika_Test\Test_3_in_1";
            string testFile = "Vopros.txt"; 

            string[] str = File.ReadAllLines(Path.Combine(testFolder, testFile));
            foreach(string st in str)
            Console.WriteLine(st);

            Console.ReadKey();
        }
    }
}
