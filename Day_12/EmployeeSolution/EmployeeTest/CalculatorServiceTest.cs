using EmployeeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest
{
    [TestClass]
    public class CalculatorServiceTest
    {
        [TestMethod("Testing Add Method of Calculator with maximum int value")]

        public void AddTest()
        {
            //Arrange
            int num1 = int.MaxValue, num2 = 100;
            CalculatorService calculatorService = new CalculatorService();
            //Action
            int result = calculatorService.Add(num1, num2);
            int expected = int.MaxValue - 100;
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod("Testing Product Method of Calculator with maximum int value")]



        public void ProductTest()
        {
            //Arrange
            int num1 = int.MaxValue, num2 = 100;
            CalculatorService calculatorService = new CalculatorService();
            //Action
            int result = calculatorService.Product(num1, num2);
            int expected = int.MaxValue - 100;
            //Assert
            Assert.AreEqual(expected, result);
        }



        [TestMethod("Testing Divide Method of Calculator with maximum int value")]



        public void DivideTest()
        {
            //Arrange
            int num1 = int.MaxValue, num2 = 100;
            CalculatorService calculatorService = new CalculatorService();
            //Action
            int result = calculatorService.Divide(num1, num2);
            int expected = int.MaxValue - 100;
            //Assert
            Assert.AreEqual(expected, result);
        }



        [TestMethod("Testing Subract Method of Calculator with maximum int value")]



        public void SubractTest()
        {
            //Arrange
            int num1 = int.MaxValue, num2 = 100;
            CalculatorService calculatorService = new CalculatorService();
            //Action
            int result = calculatorService.Subract(num1, num2);
            int expected = int.MaxValue - 100;
            //Assert
            Assert.AreEqual(expected, result);
        }

       
    }
}
