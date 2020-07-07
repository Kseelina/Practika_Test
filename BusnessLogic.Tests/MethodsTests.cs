using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic; // Библиотека для типа лист


namespace BusnessLogic.Tests
{
    [TestClass]
    public class MethodsTests
    {
        [TestMethod]
        public void GetQuestionTests()
        {
            bool expected = true; // переменная для сравнения с тем имеется ли что-то в файле

            Metods metods = new Metods();
            List<string> Text = metods.GetQuestions();

            bool actual = Text.Count > 0 ? true : false; // actual - это проверка есть ли в файле что-то
            Assert.AreEqual(expected, actual); // сравниваем expected и actual

        }
    }
}
