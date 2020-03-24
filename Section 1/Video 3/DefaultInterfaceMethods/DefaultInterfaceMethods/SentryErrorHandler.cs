using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DefaultInterfaceMethods
{
    public class SentryErrorHandler : IErrorHandler
    {
        private readonly string _sentryUrl = "https://sentry.something/api/log";

        public async Task LogError(Exception ex)
        {
            HttpClient http = new HttpClient();
            var message = JsonSerializer.Serialize(new
            {
                Message = ex.Message
            });
            await http.PostAsync(_sentryUrl, new StringContent(message));
        }
    }
}
