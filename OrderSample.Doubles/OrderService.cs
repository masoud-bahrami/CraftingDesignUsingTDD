using System.Threading.Tasks;
using TDD.Samples.Doubles.CustomerService;
using TDD.Samples.Doubles.Domain;
using TDD.Samples.Doubles.EventPublisher;
using TDD.Samples.Doubles.Exceptions;
using TDD.Samples.Doubles.Logger;
using TDD.Samples.Doubles.Repository;

namespace TDD.Samples.Doubles
{
    public class OrderServiceFacade : IOrderServiceFacade
    {
        private readonly ICustomerService _customerService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IOrderRepository _orderRepository;
        private readonly IHiLoService _hiLoService;
        private readonly ILogger _logger;

        public OrderServiceFacade()
        {
            _customerService = new CustomerService.CustomerService();
            _eventPublisher = new KafkaEventPublisher();
            _hiLoService = new HiloService();
            _logger = LoggerFactory.FileLoggerInstance();
            _orderRepository = new OrderRepository();
        }

        public Task CreateOrder(string customerId)
        {
            var customer = _customerService.GetCustomer(customerId);
            if (customer == null)
                throw new OrderApplicationException("مشتری مورد یافت نشد");
            if (customer.IsDisabled)
                throw new OrderApplicationException("مشتری غیر فعال می باشد");

            var key = _hiLoService.GenerateNeKey();
            var orderId = new OrderId(key);

            var order = new Order(orderId, customer.Id);

            _orderRepository.Create(order);

            _eventPublisher.Publish(new OrderCreated(order.Id));
            
            _logger.Log(LogType.Info, System.DateTime.Now, "یک سفارش برای مشتری با ای دی " + customerId + "به ثبت رسید");

            return Task.CompletedTask;
        }
    }
}
