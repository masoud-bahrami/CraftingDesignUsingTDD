using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

namespace TDD.CodeKata.MultiCurrency
{
    public class Bank
    {
        private IDictionary<Pair , int> rates = new Dictionary<Pair , int>();

        public Money Reduce(IExpression expression, string to)
        {
            return expression.Reduce(this , to);
        }

        public void AddRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from , to) , rate);
        }

        public int Rate(string from, string to)
        {
            if (from.Equals(to))
                return 1;

            return rates[new Pair(from, to)];
        }
    }
    public class Pair
    {
        public string From;
        public string To;
        public Pair(string from ,string to)
        {
            From = from;
            To = to;
        }

        public override bool Equals(object? obj)
        {
            Pair other = (Pair) obj;
            return this.From.Equals(other.From)
                && this.To.Equals(other.To);
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}