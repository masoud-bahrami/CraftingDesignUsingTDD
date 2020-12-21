namespace TDD.Samples.Doubles.Domain
{
    public class Order
    {
        public Order(OrderId id , string customerId)
        {
            Id = id;
        }

        public OrderId Id { get; set; }
    }
}