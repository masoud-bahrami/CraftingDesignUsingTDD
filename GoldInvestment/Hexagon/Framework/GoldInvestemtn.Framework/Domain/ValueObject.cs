namespace GoldInvestment.ApplicationService
{
    public abstract class ValueObject
    {
        public abstract bool IsEqual(ValueObject valueObject);

        public override bool Equals(object obj)
        {
            ValueObject that = (ValueObject)obj;
            return IsEqual(that);
        }
    }
}