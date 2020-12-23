namespace WeatherForecast.SmsAdapter
{
    public interface ISmsAdapter
    {
        void Run();
        void OnReceivingSms(string @from, string message);
    }

    public class SmsAdapter : ISmsAdapter
    {
        public void Run()
        {
            throw new System.NotImplementedException();
        }

        public void OnReceivingSms(string @from, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}