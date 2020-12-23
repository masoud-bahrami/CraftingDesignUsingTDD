using System;
using System.Threading.Tasks;
using WeatherForeCast.ConsoleAdapter;
using WeatherForecast.Hexagon;
using WeatherForecast.Hexagon.DrivenPorts;
using WeatherForecast.Hexagon.DriverPorts;
using WeatherForecast.Hexagon.Exceptions;
using WeatherForecast.SmsAdapter;
using Xunit;

namespace WeatherForecast.Tests
{
    public class WeatherForecastTests
    {
        //Console Adapter
        //Sms Adapter
        //Weather Inquiry Services (Adapters)

        //Convert Fahrenheit Celsius

        //Sms Driver Adapter 
        //Sms Driven Adapter


        [Fact]
        public async Task TestWeatherReaderServiceIsNull()
        {
            IWeatherReaderPort nullWeatherReaderPort = null;

            //Hexagon
            var result = Assert.Throws<ArgumentNullException>(() => CreateForecastPort(nullWeatherReaderPort));

            Assert.True(result.Message.Contains("IWeatherReaderPort"));
        }

        [Fact]
        public async Task TestWeatherReaderServiceIsUnavailable()
        {
            //Driven port 
            //Right side
            IWeatherReaderPort weatherReaderPort = WeatherReaderPortStub.WhichUnavailable();

            //Hexagon
            IWeatherForecastPort sut = CreateForecastPort(weatherReaderPort);
            var result = await Assert.ThrowsAnyAsync<WeatherReaderServiceUnavailableException>(() => sut.GetTodayWeather());

            Assert.Equal("سرویس در دسترس نمی باشد", result.Message);
        }

        [Theory]
        [InlineData(68, 20)]
        [InlineData(75.2, 24)]
        [InlineData(120.02, 48)]
        public async Task TestConvertFahrenheitToCelsius(double fahrenheit, int expectedResult)
        {
            //Data Driven Test
            //Scenario Outline
            //Parameterized Tests
            ITempratureConverter sut = CreateTempratureConverter();

            var result = sut.ConvertFahrenheitToCelsius(fahrenheit);
            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void TestShowWeatherResultToConsoleAdapter()
        {
            //Hexagon
            var todayWeahterInFahrenheit = 68;
            var formatedWeatherStatus = "دمای هوای امروز 20 درجه است";

            IWeatherForecastPort weatherReaderPort = CreateForecastPort(WeatherReaderPortStub.WhichReturn(todayWeahterInFahrenheit));

            IConsoleWriter consoleWriter = new MockConsoleWriter();
            ((MockConsoleWriter)consoleWriter).Setup(expectedMessage: formatedWeatherStatus);

            //Driver Side
            IConsoleAdapter sut = new ConsoleAdapter(consoleWriter, port: weatherReaderPort);

            sut.Run();

            //Assert
            ((MockConsoleWriter)consoleWriter).Verify();
        }


        //Current
        [Fact]
        public void TestSendWeatherStatusVisSms()
        {
            var todayWeatherInFahrenheit = 68;
            var formatedWeatherStatus = "دمای هوای امروز 20 درجه است";

            var message = "1";
            var number = "09123456789";

            MockSmsSenderPort mockSmsAdapter = new MockSmsSenderPort();
            mockSmsAdapter.Setup(expectedNumber: number, expectedMessage: formatedWeatherStatus);

            //hexagon
            IWeatherForecastPort weatherReaderPort = CreateForecastPort(WeatherReaderPortStub.WhichReturn(todayWeatherInFahrenheit), mockSmsAdapter);

            ISmsAdapter smsAdapter = new MockSmsAdapter(port: weatherReaderPort);

            smsAdapter.Run();

            smsAdapter.OnReceivingSms(@from: number, message: message);

            mockSmsAdapter.Verify();
        }

        //Factory Method
        private IWeatherForecastPort CreateForecastPort(IWeatherReaderPort weatherReaderPort, ISmsSenderPort smsSenderPort = null)
        {
            return new WeatherForecastService(weatherReaderPort, CreateTempratureConverter(), smsSenderPort);
        }

        private ITempratureConverter CreateTempratureConverter() => new TempratureConverter();
    }
}
