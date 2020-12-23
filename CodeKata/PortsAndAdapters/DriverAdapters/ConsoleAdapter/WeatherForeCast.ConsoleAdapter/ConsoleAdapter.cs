using System.Threading.Tasks;
using WeatherForecast.Hexagon.DriverPorts;

namespace WeatherForeCast.ConsoleAdapter
{
    public class ConsoleAdapter : IConsoleAdapter
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IWeatherForecastPort _port;

        public ConsoleAdapter(IConsoleWriter consoleWriter, IWeatherForecastPort port)
        {
            _consoleWriter = consoleWriter;
            _port = port;
        }

        public async Task Run()
        {
            var result =await _port.GetTodayWeather();
            _consoleWriter.WriteLine(result);
        }
    }
}