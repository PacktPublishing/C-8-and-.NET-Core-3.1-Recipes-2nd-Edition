using System;
using System.Collections.Generic;
using System.Text;

namespace PatternSwitch.Errors
{
    public class ExternalServiceError : Exception
    {
        public string ServiceName { get; set; }

        public ExternalServiceError(string serviceName, string message) : base(message)
        {
            ServiceName = serviceName;
        }
    }
}
