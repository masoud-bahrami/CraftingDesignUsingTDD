using System;

namespace GoldInvestment.ApplicationService.Contract
{
    public class CreateOuncePriceCommand : ICommand
    {
        public decimal Dollar { get; }

        public CreateOuncePriceCommand(decimal dollar)
        {
            Dollar = dollar;
        }
    }
}