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
            string filePath = @"C:\Users\Brave\Documents\Visual Studio 2019\projects\C#\Practika_Test\Test_3_in_1\Vopros.txt";
            string str = File.ReadAllText(filePath);

            //foreach (string st in str)
                Console.WriteLine(str);

            Console.ReadKey();
        }
    }
}
