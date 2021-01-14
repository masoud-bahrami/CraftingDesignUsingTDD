using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldInvestment.ApplicationService.Domain
{
    public class DollarToRialChangeRate
    {
        private List<ChnageRate> _chnageRates = new List<ChnageRate>();

        public DollarToRialChangeRate(decimal rate)
        {
            if (rate <= 0)
                throw new ZeroChnageRateDomainException();

            UpdateChnageRate(rate);
        }

        public decimal LastChnageRate()
        {
            return _chnageRates
                .OrderByDescending(a => a.SpecifiedAt)
                .FirstOrDefault()
                .Rate;
        }

        public void UpdateChnageRate(decimal rate)
        {
            _chnageRates.Add(new ChnageRate
            {
                Rate = rate,
                SpecifiedAt = DateTime.Now
            });
        }

        public List<ChnageRate> GetListOfChangeRates()
        {
            return _chnageRates;
        }
    }
}