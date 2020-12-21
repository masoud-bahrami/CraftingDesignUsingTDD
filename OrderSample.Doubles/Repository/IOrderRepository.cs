using System;
using System.Collections.Generic;
using System.Linq;
using TDD.Samples.Doubles.Domain;

namespace TDD.Samples.Doubles.Repository
{
    internal interface IOrderRepository
    {
        void Create(Order order);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _dbContext;
        public OrderRepository()
        {
            _dbContext = DbContext.Instance();
        }

        public void Create(Order order)
        {
            if (_dbContext.Orders.Any(o => o.Id.Value == order.Id.Value))
                throw new ApplicationException("Duplicate order id " + order.Id.Value);

            _dbContext.Orders.Add(order);
        }
    }

    internal class DbContext
    {
        private static DbContext _instance;
        public List<Order> Orders { get; set; }

        public static DbContext Instance()
        {
            return _instance ?? new DbContext(){Orders = new List<Order>()};
        }
    }
}