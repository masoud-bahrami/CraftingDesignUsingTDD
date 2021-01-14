using System;
using System.Threading.Tasks;
using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.Contract;
using Microsoft.AspNetCore.Mvc;

namespace GoldInvestment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DollarRateController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public DollarRateController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task Post(CreateDollarRateCommand command) => _commandDispatcher.Dispatch(command);
    }
}