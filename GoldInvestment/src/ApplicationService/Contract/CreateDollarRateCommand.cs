using System;

namespace GoldInvestment.ApplicationService.Contract
{
    public class CreateDollarRateCommand : ICommand
    {
        public int Rate { get; }

        public CreateDollarRateCommand(int rate)
        {
            Rate = rate;
        }
    }
}