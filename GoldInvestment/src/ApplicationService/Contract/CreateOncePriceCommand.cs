using System;

namespace GoldInvestment.ApplicationService.Contract
{
    public class CreateOuncePriceCommand : ICommand
    {
        public int Dollar { get; }

        public CreateOuncePriceCommand(int dollar)
        {
            Dollar = dollar;
        }
    }
}