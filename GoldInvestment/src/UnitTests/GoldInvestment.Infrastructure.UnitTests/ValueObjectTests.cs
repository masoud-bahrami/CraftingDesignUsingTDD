using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests
{
    public class ValueObjectTests
    {
        [Fact]
        public void TestValueObjectEquality()
        {
            Assert.Equal(new FakeMoneyValueObject(value: 10, currency: "Dollar"), new FakeMoneyValueObject(value: 10, currency: "Dollar"));
            Assert.NotEqual(new FakeMoneyValueObject(value: 10, currency: "Dollar"), new FakeMoneyValueObject(value: 11, currency: "Dollar"));
        }
    }
}
