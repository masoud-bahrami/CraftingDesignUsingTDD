using System.Data;
using GoldInvestment.AcceptanceTests.TestSpecificHelpers;
using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.Contract;
using GoldInvestment.ApplicationService.Handlers;
using GoldInvestment.ApplicationService.QueryHandlers;
using GoldInvestment.ApplicationService.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GoldInvestment.Bootstrapper
{
    public class GoldInvestmentApplication
    {
        public static IResolver Bootstrap(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDollarToRialChangeRateRepository, DollarToRialChangeRateFakeRepository>();
            serviceCollection.AddSingleton<IOunceRateRepository, OunceRateFakeRepository>();

            serviceCollection.AddScoped<IWantToHandlerCommand<CreateDollarRateCommand>, CreateDollarRateCommandHandler>();
            serviceCollection.AddScoped<IWantToHandlerCommand<CreateOuncePriceCommand>, CreateOuncePriceCommandHandler>();
            serviceCollection.AddScoped<IGoldPriceService, GoldPriceService>();

            serviceCollection.AddScoped<IWantToHandleQuery<GetCurrentPriceOfGoldQuery, decimal>, GetCurrentPriceOfGoldQueryHandler>();


            serviceCollection.AddScoped<ICommandDispatcher, CommandDispatcher>();
            serviceCollection.AddScoped<IQueryDispatcher, QueryDispatcher>();
            serviceCollection.AddScoped<IResolver>(s => new Resolver(serviceCollection.BuildServiceProvider()));
            return new Resolver(serviceCollection.BuildServiceProvider());
        }
        public static IResolver Bootstrap() => Bootstrap(new ServiceCollection());
    }
}