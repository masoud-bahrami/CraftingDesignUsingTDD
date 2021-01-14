using System;
using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.Contract;
using Microsoft.AspNetCore.Mvc;

namespace GoldInvestment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OuncePriceController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public OuncePriceController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public void Post(CreateOuncePriceCommand command) => _commandDispatcher.Dispatch(command);
    }
}