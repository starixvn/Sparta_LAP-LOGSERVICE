using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Famex.Athena.Microservice.Logging.Model
{
    public class LogMeType
    {
        public string Message { get; set; }
        public string Level { get; set; }
        public bool IsValid => !string.IsNullOrEmpty(Message)
            && !string.IsNullOrEmpty(Level);

    }
}
