using System;
using System.Collections.Generic;
using System.Text;

namespace PatternSwitch.Errors
{
    public class HttpError : Exception
    {
        public int HttpCode { get; set; }
        public string Description { get; set; }

        public HttpError(int httpCode, string description)
        {
            HttpCode = httpCode;
            Description = description;
        }
    }
}
