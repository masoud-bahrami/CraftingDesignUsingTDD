using TDD.Samples.Doubles.Exceptions;

namespace TDD.Samples.Doubles.Logger
{
    public class FileLogger : ILogger
    {
        public void Log(LogType type, System.DateTime date, string message)
        {
            throw new LoggerException("Could not log to the file in a test environment");
        }
    }
}