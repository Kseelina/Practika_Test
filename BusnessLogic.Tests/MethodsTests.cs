using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic; // Библиотека для типа лист
using Models;
using System.IO;

namespace BusnessLogic.Tests
{
    [TestClass]
    public class MethodsTests // Модульное тестирование
    {
        [TestMethod]
        public void GetQuestionTests()
        {
            bool expected = true; // переменная для сравнения с тем имеется ли что-то в файле
            Metods metods = new Metods();
            string file = @"C:\Users\Brave\Documents\Visual Studio 2019\projects\C#\Practika_Test\Test_3_in_1\Vopros.txt";
            List <string> Text = metods.GetQuestions(file);
            bool actual = Text.Count > 0 ? true : false; // actual - это проверка есть ли в файле что-то
            Assert.AreEqual(expected, actual); // сравниваем expected и actual

        }
        [TestMethod]
        public void SetTestChek() // правильно ли, или вообще считался ли тест
        {
            bool expected = true; 
            Metods metods = new Metods();
            string file = @"C:\Users\Brave\Documents\Visual Studio 2019\projects\C#\Practika_Test\Test_3_in_1\Vopros.txt";
            List <Question> Text = metods.SetTest(file);
            bool actual = Text.Count > 0 ? true : false; 
            Assert.AreEqual(expected, actual); 

        }
    }
}
