using GoldInvestment.ApplicationService.Handlers;

namespace GoldInvestment.ApplicationService.QueryHandlers
{
    public class GetCurrentPriceOfGoldQueryHandler : IWantToHandleQuery<GetCurrentPriceOfGoldQuery, decimal>
    {

        private readonly IGoldPriceService _goldPriceService;

        public GetCurrentPriceOfGoldQueryHandler(IGoldPriceService goldPriceService)
        {
            _goldPriceService = goldPriceService;
        }

        public decimal Run(GetCurrentPriceOfGoldQuery query)
        {
            decimal dollarRate = 42000;
            decimal ouncePrice = 1;

            decimal result = _goldPriceService.ComputeGoldPrice(dollarRate, ouncePrice);
            return result;
        }
    }
}