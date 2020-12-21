namespace TDD.Samples.Doubles.Logger
{
    public interface ILogger
    {
        void Log(LogType type, System.DateTime date, string message);
    }
}