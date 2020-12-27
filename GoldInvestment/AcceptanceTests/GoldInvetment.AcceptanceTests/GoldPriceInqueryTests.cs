using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.Contract;
using Xunit;

namespace GoldInvestment.AcceptanceTests
{
    public class GoldPriceInqueryTests
    {

        [Fact]
        public void TestXYZ()
        {
            //Dollar
            CreateDollarRateCommand createDollarRateCommand = new CreateDollarRateCommand(rate: 420000);
            ISimpleContainer simpleContainer = new SimpleContainer();
            ICommandDispatcher commandDispatcher = new CommandDispatcher(simpleContainer);
            commandDispatcher.Dispatch(createDollarRateCommand);

            //Ounce
            CreateOncePriceCommand createOncePriceCommand = new CreateOncePriceCommand(dollar: 1);
            commandDispatcher.Dispatch(createOncePriceCommand);
            
            //Gold

            IQueryDispatcher queryDispatcher = null;

            GetCurrentPriceOfGoldQuery getCurrentPriceOfGoldQuery = new GetCurrentPriceOfGoldQuery();
            decimal currentPriceOfGold = queryDispatcher.RunQuery<GetCurrentPriceOfGoldQuery, decimal>(getCurrentPriceOfGoldQuery);
            //Assert
            Assert.Equal(12000000, currentPriceOfGold);
        }
    }
}
