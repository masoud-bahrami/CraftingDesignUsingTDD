namespace TestDoubles.Spy
{
    public interface ILogger
    {
        void LogInformation(System.DateTime dateTime, string id, string msg);
        void LogError(System.DateTime dateTime, string id, string msg);
    }

    partial class FileLogger : ILogger
    {
        public void LogInformation(System.DateTime dateTime, string id, string msg)
        {
            //TODO
        }

        public void LogError(System.DateTime dateTime, string id, string msg)
        {
            //TODO
        }
    }


    internal enum LogType
    {
        Error,
        Information
    }
}
