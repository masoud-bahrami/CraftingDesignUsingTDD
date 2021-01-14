using System.Collections.Generic;
using GoldInvestment.ApplicationService.Domain;
using GoldInvestment.ApplicationService.Repository;

namespace GoldInvestment.AcceptanceTests.TestSpecificHelpers
{
    public class TestSpecificRepository<T>
    {
        private List<T> chnageRates = new List<T>();

        public void Save(T entity)
        {
            chnageRates.Add(entity);
        }

    }
    public class DollarToRialChangeRateFakeRepository : TestSpecificRepository<DollarToRialChangeRate>, IDollarToRialChangeRateRepository
    {
        public void Save(DollarToRialChangeRate dollarToRialChangeRate)
        {
            base.Save(dollarToRialChangeRate);
        }
    }

    public class OunceRateFakeRepository : TestSpecificRepository<Ounce>, IOunceRateRepository
    {
        public void Save(Ounce ounce)
        {
            base.Save(ounce);
        }
    }
}
