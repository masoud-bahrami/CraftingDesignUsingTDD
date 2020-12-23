using System;
using WeatherForecast.Hexagon.DrivenPorts;

namespace WeatherForecast.Tests
{
    public class WeatherReaderPortStub : IWeatherReaderPort
    {
        public static WeatherReaderPortStub WhichUnavailable()
        {
            return new WeatherReaderPortStub
            {
                IsUnavailable = true
            };
        }

        public bool IsUnavailable { get; set; }
        public int Fahrenheit { get; set; }

        public int GetWeather()
        {
            if (IsUnavailable)
                throw new Exception("Service is unavalabale!");

            return Fahrenheit;
        }

        public static IWeatherReaderPort WhichReturn(int fahrenheit)
        {
            return new WeatherReaderPortStub
            {
                Fahrenheit = fahrenheit
            };
        }

    }
}