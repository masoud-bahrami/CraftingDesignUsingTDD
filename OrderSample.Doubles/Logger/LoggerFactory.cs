using System;

namespace TDD.Samples.Doubles.Logger
{
    public class NullLogger : ILogger
    {
        public void Log(LogType type, DateTime date, string message)
        {
            
        }
    }
    public class LoggerFactory
    {
        public static ILogger FileLoggerInstance()
        {
            return new FileLogger();
        }
        public static ILogger NullLogger()
        {
            return new NullLogger();
        }
    }
}