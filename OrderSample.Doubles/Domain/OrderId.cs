namespace TDD.Samples.Doubles.Domain
{
    public class OrderId
    {
        public OrderId(int key)
        {
            Value = key;
        }

        public int Value { get; set; }
    }
}