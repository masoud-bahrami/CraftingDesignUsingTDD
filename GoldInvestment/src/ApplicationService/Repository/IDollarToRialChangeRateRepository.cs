using GoldInvestment.ApplicationService.Domain;

namespace GoldInvestment.ApplicationService.Repository
{
    public interface IDollarToRialChangeRateRepository
    {
        void Save(DollarToRialChangeRate dollarToRialChangeRate);
    }
}