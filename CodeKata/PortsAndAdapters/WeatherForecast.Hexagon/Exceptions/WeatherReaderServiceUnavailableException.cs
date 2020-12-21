using System;

namespace WeatherForecast.Hexagon.Exceptions
{
    public class WeatherReaderServiceUnavailableException : Exception
    {
        public WeatherReaderServiceUnavailableException(string msg)
            : base(msg)
        {

        }
    }
}