namespace GoldInvestment.ApplicationService
{
    public interface IWantToHandleQuery<T, T1>
    {
        T1 Run(T query);
    }
}