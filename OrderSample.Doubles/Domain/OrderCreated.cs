        namespace TDD.Samples.Doubles.Domain
{
    public class OrderCreated : IEvent
    {
        private OrderId _orderId;

        public OrderCreated(OrderId orderId)
        {
            _orderId = orderId;
        }
    }
}