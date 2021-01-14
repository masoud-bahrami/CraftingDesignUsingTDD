using GoldInvestment.ApplicationService.QueryHandlers;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests
{
    public class GoldPriceServiceTests
    {
        //[Theory]
        //[InlineData(280000 , 1850 , 12166478.767380683953400977076)]
        //[InlineData(300000, 1850, 13035512.965050732807215332582)]
        //public void TestComputeGoldPrice(decimal dollarRate, decimal ouncePrice, decimal expectedResult)
        //{
        //    IGoldPriceService sut = new GoldPriceService();
        //    Assert.Equal(expectedResult, sut.ComputeGoldPrice(dollarRate, ouncePrice));
        //}


        [Fact]
        public void TestComputeGoldPrice()
        {
            IGoldPriceService sut = new GoldPriceService();
            Assert.Equal(12166478.767380683953400977076m, sut.ComputeGoldPrice(280000, 1850));
            Assert.Equal(13035512.965050732807215332582m, sut.ComputeGoldPrice(300000, 1850));
        }
    }
}