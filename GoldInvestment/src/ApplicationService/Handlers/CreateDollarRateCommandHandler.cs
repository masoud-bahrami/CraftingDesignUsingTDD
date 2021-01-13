using System.Threading.Tasks;
using GoldInvestment.ApplicationService.Contract;
using GoldInvestment.ApplicationService.Domain;
using GoldInvestment.ApplicationService.Repository;

namespace GoldInvestment.ApplicationService.Handlers
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
