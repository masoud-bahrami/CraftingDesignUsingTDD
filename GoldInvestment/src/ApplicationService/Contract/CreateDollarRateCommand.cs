using System;

namespace GoldInvestment.ApplicationService.Contract
{
    public class CreateDollarRateCommand : ICommand
    {
        public decimal Rate { get; }

        public CreateDollarRateCommand(decimal rate)
        {
            Rate = rate;
        }
    }
}