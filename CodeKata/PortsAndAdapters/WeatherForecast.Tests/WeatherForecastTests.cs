using System.Threading.Tasks;
using WeatherForecast.Hexagon;
using WeatherForecast.Hexagon.DrivenPorts;
using WeatherForecast.Hexagon.DriverPorts;
using WeatherForecast.Hexagon.Exceptions;
using Xunit;

namespace WeatherForecast.Tests
{
    public class WeatherForecastTests
    {
        //Console Adapter
        //Sms Adapter
        //Weather Services (Adapters)



        //Convert Fahrenheit Celsius
        //Sms Driver Adapter 
        //Sms Driven Adapter

        [Fact]
        public async Task TestWeatherReaderServiceIsUnavailable()
        {
            IWeatherReaderPort weatherReaderPort = default;
            //Hexagon
            IWeatherForecastPort sut = new WeatherForecastService(weatherReaderPort);

            var result =
                await Assert.ThrowsAsync<WeatherReaderServiceUnavailableException>(() => sut.GetTodayWeather());
            Assert.Equal("سرویس در دسترس نمی باشد", result.Message);
        }

        [Fact]
        public async Task TestConvertFahrenheitToCelsius()
        {
            //Driven port 
            //Right side
            IWeatherReaderPort weatherReaderPort = new WeatherReaderPortTestSpecific();
            
            //Hexagon
            IWeatherForecastPort sut = new WeatherForecastService(weatherReaderPort);
            var result = await sut.GetTodayWeather();

            Assert.Equal("دمای هوای امروز 20 درجه است", result);
        }

    }

    public  class WeatherReaderPortTestSpecific: IWeatherReaderPort
    {
        public int GetWeather()
        {
            return 68;
        }
    }
}
