using TDD.Samples.Doubles.Exceptions;

namespace TDD.Samples.Doubles.CustomerService
{
    internal class CustomerService : ICustomerService
    {
        public CustomerViewModel GetCustomer(string customerId)
        {
            if (customerId == "1")
                return null;

            if (customerId == "2")
                return new CustomerViewModel
                {
                    IsDisabled = true
                };

            throw new OrderApplicationException("Could not get customer info from Customer-Microservice");
        }
    }
}