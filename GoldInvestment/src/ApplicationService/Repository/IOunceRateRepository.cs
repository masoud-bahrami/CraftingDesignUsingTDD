using GoldInvestment.ApplicationService.Domain;

namespace GoldInvestment.ApplicationService.Repository
{
    public interface IOunceRateRepository
    {
        void Save(Ounce ounce);
    }
}