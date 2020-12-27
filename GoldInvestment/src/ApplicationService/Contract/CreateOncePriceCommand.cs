using System;

namespace GoldInvestment.ApplicationService.Contract
{
    public class CreateOncePriceCommand : ICommand
    {
        public int Dollar { get; }

        public CreateOncePriceCommand(int dollar)
        {
            Dollar = dollar;
        }
    }
}