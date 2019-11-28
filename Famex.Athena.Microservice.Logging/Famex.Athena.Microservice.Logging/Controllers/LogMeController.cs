using Famex.Athena.Microservice.Logging.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Famex.Athena.Microservice.Logging.Controllers
{
    [Route("api/[controller]")]
    public class LogMeController : Controller
    {
        private readonly List<string> ErrorLogLevel = new List<string> { "Error", "Warn" };
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public LogMeController(ILogger<LogMeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public List<string> Get()
        {
            return ErrorLogLevel;
        }
        // POST api/values
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public void Post([FromForm] LogMeType value)
        {
            if (value != null && value.IsValid)
            {
                if (ErrorLogLevel.Contains(value.Level, StringComparer.InvariantCultureIgnoreCase))
                {
                    _logger.LogError(value.Message);
                }
                else
                {
                    _logger.LogWarning(value.Message);
                }
            }
        }
    }
}
