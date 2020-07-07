using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusnessLogic
{
   public class Metods
    {
      public  string[] GetQuestions()
        { 
        string testFolder = @"C:\Users\Brave\Documents\Visual Studio 2019\projects\C#\Practika_Test\Test_3_in_1";
        string testFile = "Vopros.txt";

        string[] str = File.ReadAllLines(Path.Combine(testFolder, testFile));
        return str;
        }

       
    }
}
