using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TestDoubles.Dummy.Tests

{
    public class NullLogger : ILogger
    {
        public void Log(string message)
        {

        }
    }
    public class OrderTests
    {
        //Create a new Order
        //Get an existing order
        //Sheep the order

        [Fact]
        public void TestAddOrder()
        {
            IOrderRepository orderRepository = new OrderRepositoryInMemory();

            //DUMMY
            INotificationService notificationService = default;
            ILogger logger = new NullLogger();

            var orderService = new OrderService(orderRepository,
                notificationService,
                logger);

            IList<Address> addresses = null;
            Customer customer = new Customer("1" , "Ali" , "Ahmadi" , addresses);
            orderService.CreateOrderFor(new OrderId("1") , customer);

            Assert.Equal(new OrderId("1"), orderRepository.Get("1").Id);
        }
    }

    public class OrderRepositoryInMemory : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();
        public void Create(Order order)
        {
            _orders.Add(order);
        }

        public Order Get(string orderId) => _orders.Single(o => o.Id.Equals(new OrderId(orderId)));
    }
}
