using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace MsTest
{
    [TestClass]
    public class CalculatorTests
    {

        private static IEnumerable<object[]> GetSumData()
        {
            yield return new object[] { 5, 15, 20 };
            yield return new object[] { 5, 1, 6 };
        }


        public static Calculator sut;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            sut = new Calculator();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //sut.Dispose();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //sut = new Calculator();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            sut.Dispose();
        }
        
        [TestMethod]
        [DataRow(5, 6, 11)]
        [DataRow(5, 10, 15)]
        [DynamicData(nameof(GetSumData), DynamicDataSourceType.Method)]
        [CustomSumData]
        public void TestSum(int augend, int addend, int expectedResult)
        {
            var result = sut.Sum(augend, addend);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            var augend = 5;
            var multiplier = 6;
            var expectedResult = 30;
            var result = sut.Multiply(augend, multiplier);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestDivision()
        {
            var numerator = 30;
            var denominator = 6;
            var expectedResult = 5;

            var result = sut.Division(numerator, denominator);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        //[ExpectedException(typeof(DivideByZeroException))]
        public void TestDivisionByZero()
        {
            var numerator = 30;
            var denominator = 0;

            var result = Assert.ThrowsException<DivideByZeroException>(() => sut.Division(numerator, denominator));

        }
    }
}