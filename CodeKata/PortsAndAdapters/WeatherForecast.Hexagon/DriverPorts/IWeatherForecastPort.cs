using System.Threading.Tasks;

namespace WeatherForecast.Hexagon.DriverPorts
{
    public interface IWeatherForecastPort
    {
        Task<string> GetTodayWeather();
    }
}