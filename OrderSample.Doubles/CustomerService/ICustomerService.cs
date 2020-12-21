namespace TDD.Samples.Doubles.CustomerService
{
    public interface ICustomerService
    {
        CustomerViewModel GetCustomer(string customerId);
    }
}