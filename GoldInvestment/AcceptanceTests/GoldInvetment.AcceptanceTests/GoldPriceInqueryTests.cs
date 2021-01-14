using System.Runtime.InteropServices;
using GoldInvestment.AcceptanceTests.Drivers;
using GoldInvestment.AcceptanceTests.TestSpecificHelpers;
using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.Contract;
using GoldInvestment.ApplicationService.Handlers;
using GoldInvestment.ApplicationService.QueryHandlers;
using GoldInvestment.ApplicationService.Repository;
using Xunit;

namespace GoldInvestment.AcceptanceTests
{
    public class GoldPriceInquiryTests
    {
        
        [Fact]
        public async void CurrentPriceOfGold()
        {
            //Dollar
            const decimal dollarRate = 28000;
            const decimal ouncePrice = 1850;
            const decimal expectedCurrentGoldPrice = 986.4712514092446448703494927m;
            
            var createDollarRateCommand = new CreateDollarRateCommand(rate: dollarRate);
            var createOncePriceCommand = new CreateOuncePriceCommand(dollar: ouncePrice);

            IGoldInvestmentApplicationDriver applicationDriver = new GoldInvestmentApplicationApiDriver();

            await applicationDriver.Bootstrap();
            await applicationDriver.CreateDollarPrice(createDollarRateCommand);
            await applicationDriver.CreateOuncePrice(createOncePriceCommand);

            decimal currentPriceOfGold =await applicationDriver.GetCurrentGoldPrice();
            
            Assert.Equal(expectedCurrentGoldPrice, currentPriceOfGold);
        }
    }
}
