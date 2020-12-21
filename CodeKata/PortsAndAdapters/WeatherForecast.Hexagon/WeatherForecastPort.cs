using System.Threading.Tasks;
using WeatherForecast.Hexagon.DrivenPorts;
using WeatherForecast.Hexagon.DriverPorts;
using WeatherForecast.Hexagon.Exceptions;

namespace WeatherForecast.Hexagon
{
    public class WeatherForecastService : IWeatherForecastPort
    {
        private readonly IWeatherReaderPort _weatherForecastPort;

        public WeatherForecastService(IWeatherReaderPort weatherForecastPort)
        {
            _weatherForecastPort = weatherForecastPort;
        }

        public async Task<string> GetTodayWeather()
        {
            if (_weatherForecastPort == null)
                throw new WeatherReaderServiceUnavailableException("سرویس در دسترس نمی باشد");

            int firhenheit = _weatherForecastPort.GetWeather();

            return $"دمای هوای امروز {FarhenheitToCelcius(firhenheit)} درجه است";
        }

        private int FarhenheitToCelcius(int firhenheit)
        {
            return (firhenheit - 32) * 5 / 9;
        }
    }
}