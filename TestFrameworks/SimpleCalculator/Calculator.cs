using System;

namespace CalculatorSample
{
    public class Calculator : IDisposable
    {
        public int Add(int augend, int addend)
        {
            return augend + addend;
        }

        public int Multiply(int augend, int multiplier)
        {
            return augend * multiplier;
        }
        public int Division(int numerator, int denominator)
        {
            if(denominator == 0)
                throw new DivideByZeroException();

            return numerator / denominator;
        }

        public void Dispose()
        {
        }
    }
}