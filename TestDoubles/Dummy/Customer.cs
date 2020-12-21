using System.Collections.Generic;

namespace TestDoubles.Dummy
{

    public class Customer
    {
        public Customer(string customerId, 
            string firstName, 
            string lastName, 
            IList<Address> addresses)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Addresses = addresses;
        }

        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}