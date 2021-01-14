using System;
using System.Threading.Tasks;
using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.QueryHandlers;
using Microsoft.AspNetCore.Mvc;

namespace GoldInvestment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoldPriceController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public GoldPriceController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<decimal> Get()
            => _queryDispatcher.RunQuery<GetCurrentPriceOfGoldQuery, decimal>(new GetCurrentPriceOfGoldQuery());
    }
}