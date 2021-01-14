using System.Threading.Tasks;
using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.Contract;
using GoldInvestment.ApplicationService.QueryHandlers;
using GoldInvestment.Bootstrapper;

namespace GoldInvestment.AcceptanceTests.Drivers
{
    public class GoldInvestmentApplicationHexagonDriver : IGoldInvestmentApplicationDriver
    {
        private ICommandDispatcher _commandDispatcher;

        private IQueryDispatcher _queryDispatcher;

        public async Task Bootstrap()
        {
            IResolver resolver =  GoldInvestmentApplication.Bootstrap();
            
            _commandDispatcher = new CommandDispatcher(resolver);
            _queryDispatcher = new QueryDispatcher(resolver);
        }

        public async Task CreateDollarPrice(CreateDollarRateCommand createDollarRateCommand) => _commandDispatcher.Dispatch(createDollarRateCommand);

        public async Task CreateOuncePrice(CreateOuncePriceCommand createOncePriceCommand) => _commandDispatcher.Dispatch(createOncePriceCommand);

        public async Task<decimal> GetCurrentGoldPrice() =>
            _queryDispatcher.RunQuery<GetCurrentPriceOfGoldQuery, decimal>(
                new GetCurrentPriceOfGoldQuery());
    }
}