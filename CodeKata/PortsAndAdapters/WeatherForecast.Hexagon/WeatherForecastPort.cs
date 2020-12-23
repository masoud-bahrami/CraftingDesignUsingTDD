using System;
using System.Threading.Tasks;
using WeatherForecast.Hexagon.DrivenPorts;
using WeatherForecast.Hexagon.DriverPorts;
using WeatherForecast.Hexagon.Exceptions;

namespace WeatherForecast.Hexagon
{
    public class WeatherForecastService : IWeatherForecastPort
    {
        private readonly IWeatherReaderPort _weatherForecastPort;
        
        //Interface >> abstract
        //Program to abstract> program to interface

        private readonly ITempratureConverter _tempratureConverter;
        private readonly   ISmsSenderPort _smsSenderPort;

        public WeatherForecastService(IWeatherReaderPort weatherForecastPort, ITempratureConverter tempretureConverter, ISmsSenderPort smsSenderPort)
        {
            //Fail fast
            //Guard Clouse
            if (weatherForecastPort == null)
                throw new ArgumentNullException(@"IWeatherReaderPort");

            _weatherForecastPort = weatherForecastPort;
            _tempratureConverter = tempretureConverter;
            _smsSenderPort = smsSenderPort;
        }

        public async Task<string> GetTodayWeather()
        {
            try
            {
                int fahrenheit = _weatherForecastPort.GetWeather();
                return $"دمای هوای امروز {FahrenheitToCelsius(fahrenheit)} درجه است";
            }
            catch (Exception)
            {
                throw new WeatherReaderServiceUnavailableException("سرویس در دسترس نمی باشد");
            }

        }

        public void SendWeatherStatusTo(string @from)
        {
            //TODO

            var fahrenheit = _weatherForecastPort.GetWeather();
            var message = $"دمای هوای امروز {FahrenheitToCelsius(fahrenheit)} درجه است";

            _smsSenderPort.SendSms(to: @from, message: message);
        }

        private int FahrenheitToCelsius(int fahrenheit)
        {
            return _tempratureConverter.ConvertFahrenheitToCelsius(fahrenheit);

        }
    }
}