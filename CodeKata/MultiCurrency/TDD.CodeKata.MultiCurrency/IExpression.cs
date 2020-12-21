namespace TDD.CodeKata.MultiCurrency
{
    public interface IExpression
    {
        Money Reduce(Bank bank, string to);
        Sum Plus(IExpression expression);
    }
}