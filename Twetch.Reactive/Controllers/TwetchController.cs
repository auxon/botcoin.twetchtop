using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Twetch.Reactive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwetchController : ControllerBase
    {
        private readonly ILogger<TwetchController> _logger;

        public TwetchController(ILogger<TwetchController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public async IAsyncEnumerable<Twetch> Get()
        //{

        //}
    }
}
