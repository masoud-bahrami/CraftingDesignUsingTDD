using GoldInvestment.ApplicationService.Domain;
using GoldInvestment.ApplicationService.Repository;
using System.Collections.Generic;

namespace GoldInvestment.Adapters.Repository
{
    public class FakeRepository : IDollarToRialChangeRateRepository
    {
        private List<DollarToRialChangeRate> chnageRates = new List<DollarToRialChangeRate>();

        public void Save(DollarToRialChangeRate dollarToRialChangeRate)
        {
            chnageRates.Add(dollarToRialChangeRate);
        }
    }
}
