using System.Threading.Tasks;
using GoldInvestment.ApplicationService.Contract;

namespace GoldInvestment.AcceptanceTests.Drivers
{
    public interface IGoldInvestmentApplicationDriver
    {
        Task Bootstrap();
        Task CreateDollarPrice(CreateDollarRateCommand createDollarRateCommand);
        Task CreateOuncePrice(CreateOuncePriceCommand createOncePriceCommand);
        Task<decimal> GetCurrentGoldPrice();
    }
}