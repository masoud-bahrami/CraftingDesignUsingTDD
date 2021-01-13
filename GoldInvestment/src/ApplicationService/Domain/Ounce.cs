using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldInvestment.ApplicationService.Domain
{
    public class Ounce
    {
        private List<OunceRate> _chnageRates = new List<OunceRate>();

        public Ounce(decimal rate)
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
            _chnageRates.Add(new OunceRate
            {
                Rate = rate,
                SpecifiedAt = DateTime.Now
            });
        }

        public List<OunceRate> GetListOfChangeRates()
        {
            return _chnageRates;
        }
    }
}