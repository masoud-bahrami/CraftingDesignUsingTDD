namespace WeatherForecast.Hexagon
{
    public interface ITempratureConverter
    {
        int ConvertFahrenheitToCelsius(double fahrenheit);
    }

    public class TempratureConverter : ITempratureConverter
    {
        public int ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (int) ((fahrenheit - 32) * 5 / 9);
        }
    }
}