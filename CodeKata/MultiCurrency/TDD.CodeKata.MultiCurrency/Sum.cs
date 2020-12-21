namespace TDD.CodeKata.MultiCurrency
{
    public class Sum: IExpression
    {
        public IExpression Augend;
        public IExpression Addend;

        public Sum(IExpression augend , IExpression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(Bank bank, string to)
        {
            int amount = Augend.Reduce(bank , to).Amount + Addend.Reduce(bank , to).Amount;
            return new Money(amount , to);
        }

        public Sum Plus(IExpression expression)
        {
            return new Sum(this , expression);
        }
    }
}