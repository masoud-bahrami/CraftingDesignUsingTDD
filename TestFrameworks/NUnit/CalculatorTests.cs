using System.Collections.Generic;
using NUnit.Framework;
using SimpleCalculator;

namespace EnUnit
{

    public class CalculatorTests
    {
        public Calculator Sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Sut = new Calculator();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Sut.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            Sut = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            Sut.Dispose();
        }

        [Test]
        public void TestSum()
        {
            var augend = 5;
            var addend = 10;
            var expectedResult = 15;
            var result = Sut.Sum(augend, addend);
            Assert.AreEqual(expectedResult, result);
        }


        private static IEnumerable<object[]> GetSumDataSource(string mode)
        {
            if (mode == "happy")
            {
                yield return new object[] { 10, 20, 30 };
                yield return new object[] { 10, 30, 40 };
            }
            else
            {
                yield return new object[] { 10, 20, 10 };
                yield return new object[] { 10, 30, 12 };
            }
        }

        [TestCase(5, 10, 15)]
        [TestCase(5, 20, 25)]
        [TestCaseSource(nameof(GetSumDataSource), new object[] { "happy" })]
        public void TestSum_Parameterized(int augend, int addend, int expectedResult)
        {
            Calculator sut = new Calculator();
            var result = sut.Sum(augend, addend);
            Assert.AreEqual(expectedResult, result);
        }


        [TestCaseSource(nameof(GetSumDataSource), new object[] { "happy" })]
        public void TestSum_Parameterized1(int augend, int addend, int expectedResult)
        {
            var result = Sut.Sum(augend, addend);
            Assert.AreEqual(expectedResult, result);
        }
    }
}