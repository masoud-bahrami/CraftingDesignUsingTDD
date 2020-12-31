using GoldInvestment.ApplicationService;

namespace GoldInvestment.Infrastructure.UnitTests
{
    internal class FakeMoneyValueObject : ValueObject
    {
        private int value;
        private string currency;

        public FakeMoneyValueObject(int value, string currency)
        {
            this.value = value;
            this.currency = currency;
        }

        public override bool IsEqual(ValueObject valueObject)
        {
            FakeMoneyValueObject that = (FakeMoneyValueObject)valueObject;
            
            return (this.value == that.value && this.currency == that.currency);
        }
    }
}