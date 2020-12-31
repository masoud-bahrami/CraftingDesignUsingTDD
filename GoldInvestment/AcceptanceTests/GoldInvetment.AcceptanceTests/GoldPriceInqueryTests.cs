using GoldInvestment.Adapters.Repository;
using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.Contract;
using GoldInvestment.ApplicationService.Handers;
using GoldInvestment.ApplicationService.Repository;
using Xunit;

namespace GoldInvestment.AcceptanceTests
{
    public class GoldPriceInqueryTests
    {


        //WebService >> DollarToRial Change rate 
        //IDollarToRialWebService
        // Event 
        [Fact]
        public void TestXYZ()
        {
            //Dollar
            CreateDollarRateCommand createDollarRateCommand = new CreateDollarRateCommand(rate: 420000);
            ISimpleContainer simpleContainer = new SimpleContainer();

            //Required Interface
            IDollarToRialChangeRateRepository repo = new FakeRepository();

            //component Lifetime Management

            simpleContainer.Register(typeof(CreateDollarRateCommand), () => new CreateDollarRateCommandHandler(repo));
            
            ICommandDispatcher commandDispatcher = new CommandDispatcher(simpleContainer);
            commandDispatcher.Dispatch(createDollarRateCommand);

            //Ounce
            CreateOuncePriceCommand createOncePriceCommand = new CreateOuncePriceCommand(dollar: 1);
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
