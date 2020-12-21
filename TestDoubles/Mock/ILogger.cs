namespace TestDoubles.Mock
{
    public interface ILogger
    {
        void LogInformation(System.DateTime dateTime, string id, string msg);
        void LogError(System.DateTime dateTime, string id, string msg);
    }
}