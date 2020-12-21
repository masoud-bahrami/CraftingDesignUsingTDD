namespace TestDoubles.Dummy
{
    public class Order
    {
        public readonly OrderId Id;
        private readonly string _customerId;

        public Order(OrderId id , string customerId)
        {
            Id = id;
            _customerId = customerId;
        }


    }
}