using System.Collections;
using System.Collections.Generic;

namespace ExUnit
{
    public class CalculatorDataHelper : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 50, 50, 100 };
            yield return new object[] { 100, 300, 400 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}