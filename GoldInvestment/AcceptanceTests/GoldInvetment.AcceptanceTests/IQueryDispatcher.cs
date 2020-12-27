namespace GoldInvestment.AcceptanceTests
{
    public interface IQueryDispatcher
    {
        T1 RunQuery<T, T1>(T query);
    }
}