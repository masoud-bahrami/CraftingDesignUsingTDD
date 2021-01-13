using System.Threading.Tasks;
using GoldInvestment.ApplicationService.Contract;
using GoldInvestment.ApplicationService.Domain;
using GoldInvestment.ApplicationService.Repository;

namespace GoldInvestment.ApplicationService.Handlers
{
    public class CreateOuncePriceCommandHandler : IWantToHandlerCommand<CreateOuncePriceCommand>
    {
        private readonly IOunceRateRepository _repo;

        public CreateOuncePriceCommandHandler(IOunceRateRepository repo)
        {
            _repo = repo;
        }

        public Task Handle(CreateOuncePriceCommand command)
        {
            var dollarToRialChangeRate = new Ounce(command.Dollar);
            _repo.Save(dollarToRialChangeRate);

            return Task.CompletedTask;
        }
    }
}
