using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GoldInvestment.Api;
using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.Contract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace GoldInvestment.AcceptanceTests.Drivers
{
    public class GoldInvestmentApplicationApiDriver : IGoldInvestmentApplicationDriver
    {
        //Fake
        private TestServer server;
        private HttpClient _httpClient;


        public async Task Bootstrap()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>();

            server = new TestServer(webHostBuilder);

            _httpClient = server.CreateClient();
        }

        public async Task CreateDollarPrice(CreateDollarRateCommand createDollarRateCommand)
        {
            var url = "/api/dollarRate";
            await PostAsync(url, createDollarRateCommand);

        }



        public async Task CreateOuncePrice(CreateOuncePriceCommand createOncePriceCommand)
        {
            var url = "/api/ouncePrice";

            await PostAsync(url, createOncePriceCommand);
        }

        public async Task<decimal> GetCurrentGoldPrice()
        {
            var url = "/api/goldPrice";
            var responseMessage = await _httpClient.GetAsync(url);
            responseMessage.EnsureSuccessStatusCode();
            Assert.True(responseMessage.IsSuccessStatusCode);

            var result = await responseMessage.Content.ReadAsStringAsync();
            return decimal.Parse(result);
        }


        private async Task PostAsync(string url, ICommand command)
        {
            var result = await _httpClient.PostAsync(url, CreateStringContent(command));
            result.EnsureSuccessStatusCode();
            Assert.True(result.IsSuccessStatusCode);
        }

        private HttpContent CreateStringContent(ICommand createDollarRateCommand)
        {
            return new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(createDollarRateCommand), Encoding.UTF8, "application/json");
        }
    }
}