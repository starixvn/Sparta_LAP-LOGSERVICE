using Famex.Athena.Microservice.Logging.Model;
using Fanex.Logging;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public List<string> Get()
        {
            return ErrorLogLevel;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] LogMeType value)
        {
            if (value != null && value.IsValid)
            {
                if (ErrorLogLevel.Contains(value.Level, StringComparer.InvariantCultureIgnoreCase))
                {
                    Logger.Log.Error(value.Message);
                }
                else
                {
                    Logger.Log.Info(value.Message);
                }
            }
        }
    }
}
