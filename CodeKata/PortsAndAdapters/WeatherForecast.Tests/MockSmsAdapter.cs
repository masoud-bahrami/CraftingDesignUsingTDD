using System;
using WeatherForecast.Hexagon.DriverPorts;
using WeatherForecast.SmsAdapter;

namespace WeatherForecast.Tests
{
    public class MockSmsAdapter : ISmsAdapter
    {
        private readonly IWeatherForecastPort _port;

        public MockSmsAdapter(IWeatherForecastPort port)
        {
            _port = port;
        }

        public void Run()
        {
            //
        }

        public void OnReceivingSms(string @from, string message)
        {
            switch (message)
            {
                case "1":
                    _port.SendWeatherStatusTo(@from);
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}