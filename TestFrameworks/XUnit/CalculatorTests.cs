using System;
using System.Collections.Generic;
using SimpleCalculator;
using Xunit;

namespace ExUnit
{
    public class CalculatorFixture : IDisposable
    {
        protected Calculator sut;

        public CalculatorFixture()
        {
            sut = new Calculator();
        }


        public void Dispose()
        {
            sut.Dispose();
        }
    }
    public class CalculatorTests : CalculatorFixture, IClassFixture<CalculatorFixture>
    {
        [Fact]
        public void TestSum()
        {
            var augend = 5;
            var addend = 6;
            var expectedResult = 11;

            var result = sut.Sum(augend, addend);

            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> GetSumData()
        {
            yield return new object[] { 10, 20, 30 };
            yield return new object[] { 10, 30, 40 };
        }

        [Theory]
        [InlineData(5, 6, 11)]
        [InlineData(5, 10, 15)]
        [MemberData(nameof(GetSumData))]
        [ClassData(typeof(CalculatorDataHelper))]
        public void TestSum_Parameterized(int augend, int addend, int expectedResult)
        {
            var result = sut.Sum(augend, addend);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestDivisionByZero()
        {
            var numerator = 5;
            var denominator = 0;

            Assert.ThrowsAny<DivideByZeroException>(() => sut.Division(numerator, denominator));
        }
    }
}