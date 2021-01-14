namespace GoldInvestment.ApplicationService.QueryHandlers
{
    public interface IGoldPriceService
    {
        decimal ComputeGoldPrice(decimal dollarRate, decimal ouncePrice);
    }

    public class GoldPriceService : IGoldPriceService
    {
        public decimal ComputeGoldPrice(decimal dollarRate, decimal ouncePrice)
        {
            decimal oneMesqalGoldPrice = (dollarRate * ouncePrice) / 8.87m;
            return oneMesqalGoldPrice / 4.8m;
        }
    }
}