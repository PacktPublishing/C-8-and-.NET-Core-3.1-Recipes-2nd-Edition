using PatternSwitch.Errors;
using System;

namespace PatternSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //throw new HttpError(201, "Created");
                //throw new HttpError(400, "Bad Request");
                //throw new ExternalServiceError("Azure Service Bus", "Invalid Payload");
                throw new Exception();
            }
            catch(Exception ex)
            {
                var handler = new ErrorHandler();
                handler.Handle(ex);
            }
        }
    }
}
