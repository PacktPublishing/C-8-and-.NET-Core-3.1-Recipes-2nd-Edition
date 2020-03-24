using System;
using System.Collections.Generic;
using System.Text;
using PatternSwitch.Errors;

namespace PatternSwitch
{
    public class ErrorHandler
    {
        public void Handle(Exception err)
        {
            Console.WriteLine(GetErrorMessage(err));
        }

        private string GetErrorMessage(Exception err)
        {
            return err switch
            {
                HttpError httpError when httpError.HttpCode >= 200 && httpError.HttpCode < 300 => "No Error",
                HttpError httpErr when httpErr.HttpCode > 300 => $"[HTTP] [{httpErr.HttpCode}] -- {httpErr.Description}",
                ExternalServiceError ex => $"{ex.ServiceName}: {ex.Message}",
                _ => "Unknown Error"
            };
        }
    }
}
