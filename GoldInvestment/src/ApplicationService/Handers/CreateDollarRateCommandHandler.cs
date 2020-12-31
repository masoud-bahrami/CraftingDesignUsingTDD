using GoldInvestment.ApplicationService.Contract;
using GoldInvestment.ApplicationService.Domain;
using GoldInvestment.ApplicationService.Repository;
using System.Threading.Tasks;

namespace GoldInvestment.ApplicationService.Handers
{
    public class CreateDollarRateCommandHandler : IWantToHandlerCommand<CreateDollarRateCommand>
    {
        private readonly IDollarToRialChangeRateRepository _repo;

        public CreateDollarRateCommandHandler(IDollarToRialChangeRateRepository repo)
        {
            _repo = repo;
        }
        public Task Handle(CreateDollarRateCommand command)
        {
            var dollarToRialChangeRate = new DollarToRialChangeRate(command.Rate);
            _repo.Save(dollarToRialChangeRate);

            return Task.CompletedTask;
        }
    }
}
