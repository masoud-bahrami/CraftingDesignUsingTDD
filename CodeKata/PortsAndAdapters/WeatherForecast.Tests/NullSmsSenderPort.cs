using System;
using WeatherForecast.Hexagon.DrivenPorts;

namespace WeatherForecast.Tests
{
    public class NullSmsSenderPort : ISmsSenderPort
    {
        public void SendSms(string to, string message)
        {
            throw new NotImplementedException();
        }
    }
}