using System.Collections.Generic;

namespace TDD.CodeKata.MultiCurrency
{
     public class Money : IExpression
    {
        internal int Amount { get; set; }
        internal string currency;
        internal Money(int amount , string currency)
        {
            Amount = amount;
            this.currency = currency;
        }
       
        public override bool Equals(object? obj)
        {
            Money other = (Money)obj;
            return 
                this.Currency() == other.Currency() &&
                this.Amount == other.Amount;
        }

        public static Money Franc(int amount)
        {
            return new Money(amount , "CHF");
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount ,"USD");
        }

        internal string Currency()
        {
            return currency;
        }


        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, currency);
        }

        public Sum Plus(IExpression Addend)
        {
            return new Sum(this, Addend);
        }


        public Money Reduce(Bank bank, string to)
        {
            var rate = bank.Rate(Currency(), to);
            return new Money(Amount / rate , to);
        }
        public override string ToString()
        {
            return Amount + " " + Currency();
        }
    }
}