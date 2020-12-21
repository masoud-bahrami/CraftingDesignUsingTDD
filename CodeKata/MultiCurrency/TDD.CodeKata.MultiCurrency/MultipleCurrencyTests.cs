using System.Collections.Generic;
using Xunit;

namespace TDD.CodeKata.MultiCurrency
{
    public class MultipleCurrencyTests
    {
        [Fact]
        public void TestMultiplication()
        {
            Money five = (Money)Money.Dollar(5);
            Money product = five.Times(2);
            Assert.Equal(10, product.Amount);

            product = five.Times(3);
            Assert.Equal(15, product.Amount);
        }

        [Fact]
        public void TestMultiCurrency()
        {
            Assert.False(Money.Dollar(1).Equals(Money.Franc(1)));
        }

        [Fact]
        public void TestEquality()
        {
            Assert.True(Money.Dollar(1).Equals(Money.Dollar(1)));
            Assert.True(Money.Franc(5).Equals(Money.Franc(5)));
        }

        [Fact]
        public void TestCurrency()
        {
            Assert.True("USD".Equals(Money.Dollar(1).Currency()));
            Assert.True("CHF".Equals(Money.Franc(1).Currency()));
        }

        [Fact]
        public void TestSimpleAddition()
        {
            Money fiveDollar = Money.Dollar(5);
            Sum sum = (Sum)fiveDollar.Plus(fiveDollar);

            Bank bank = new Bank();

            Money result = bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(10), result);
        }

        [Fact]
        public void TestMoneyPlusReturnsSum()
        {
            Sum sum = (Sum)Money.Dollar(5).Plus(Money.Dollar(5));

            Assert.Equal(sum.Augend, Money.Dollar(5));
            Assert.Equal(sum.Addend, Money.Dollar(5));

        }

        [Fact]
        public void TestReduceSum()
        {
            IExpression sum = new Sum(Money.Dollar(5), Money.Dollar(4));
            Bank bank = new Bank();
            Money result = bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(9), result);
        }

        [Fact]
        public void TestMoneyReduce()
        {
            Bank bank = new Bank();
            Money result = bank.Reduce(Money.Dollar(1), "USD");
            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            Money result = bank.Reduce(Money.Franc(2), "USD");
            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void TestPairDictionaryEquals()
        {
            IDictionary<Pair, int> rates = new Dictionary<Pair, int>();
            rates.Add(new Pair("CHF", "USD"), 2);

            Assert.Equal(rates, new Dictionary<Pair, int> { { new Pair("CHF", "USD"), 2 } });
        }

        [Fact]
        public void TestIdentityRate()
        {
            Bank bank = new Bank();
            var result = bank.Rate("USD", "USD");
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestMixedAddition()
        {
            Money fiveDollars = Money.Dollar(5);
            Money tenFrancs = Money.Franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var result = bank.Reduce(fiveDollars.Plus(tenFrancs), "USD");
            Assert.Equal(Money.Dollar(10), result);
        }

        [Fact]
        public void TestSumPlusMoney()
        {
            IExpression fiveDollars = Money.Dollar(5);
            IExpression tenFrancs = Money.Franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            IExpression sum = new Sum(fiveDollars, tenFrancs);
            var result = bank.Reduce(sum.Plus(fiveDollars), "USD");
            Assert.Equal(Money.Dollar(15), result);
        }

    }
}

//Write test
//Make It compile
//Make it pass
//Make it right (remove duplicated codes)
//Commit (C.I)
