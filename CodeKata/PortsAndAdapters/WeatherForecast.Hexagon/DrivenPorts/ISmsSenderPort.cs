namespace WeatherForecast.Hexagon.DrivenPorts
{
    public interface ISmsSenderPort
    {
        void SendSms(string to, string message);
    }
}