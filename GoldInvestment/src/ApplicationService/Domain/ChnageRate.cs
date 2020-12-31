using System;

namespace GoldInvestment.ApplicationService.Domain
{
    public class ChnageRate : ValueObject
    {
        public DateTime SpecifiedAt { get; set; }
        public decimal Rate { get; set; }

        public override bool IsEqual(ValueObject valueObject)
        {
            var that = (ChnageRate)valueObject;
            return this.SpecifiedAt == that.SpecifiedAt
                && this.Rate == that.Rate;
        }
    }
}