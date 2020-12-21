using System;

namespace TestDoubles.Spy
{
    public class LoggerSpy : ILogger
    {
        public string ActualMessage { get; set; }

        public string ActualId { get; set; }

        public DateTime ActualDateTime { get; set; }

        public string ActualMethod { get; set; }


        public void LogInformation(DateTime dateTime, string id, string msg)
        {
            ActualMethod = nameof(LogInformation);
            ActualDateTime = dateTime;
            ActualId = id;
            ActualMessage = msg;
        }


        public void LogError(DateTime dateTime, string id, string msg)
        {
            ActualMethod = nameof(LogError);
            ActualDateTime = dateTime;
            ActualId = id;
            ActualMessage = msg;
        }
    }
}