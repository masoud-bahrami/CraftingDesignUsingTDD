namespace TestDoubles.Dummy
{
    public interface IOrderRepository
    {
        void Create(Order order);
        Order Get(string orderId);
    }
}