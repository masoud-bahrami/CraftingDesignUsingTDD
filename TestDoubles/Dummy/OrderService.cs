using System;

namespace TestDoubles.Dummy
{
    public class OrderService
    {
        //DOCs
        private readonly ILogger _logger;
        private readonly INotificationService _notificationService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository,
            INotificationService notificationService, 
            ILogger logger)
        {
            _logger = logger;
            _notificationService = notificationService;
            _orderRepository = orderRepository;
        }

        public void CreateOrderFor(OrderId orderId, Customer customer)
        {
            if(customer == default)
                throw new ArgumentNullException("Customer");

            _logger.Log("At the start of the create order service!");

            _orderRepository.Create(new Order(orderId, customer.CustomerId));

            _logger.Log("At the end of the create order service!");
        }

        public void Sheep(string orderId)
        {
            //TODO
            string mobileNumber = "09120750671";
            string message="سفارش شما در حال ارسال می باشد";

            _notificationService.SendSmsToCustomer(mobileNumber, message);
        }

        public Order Get(string orderId)
        {
            _logger.Log("At the start of the GetOrder!!");
            return _orderRepository.Get(orderId);
        }
    }
}