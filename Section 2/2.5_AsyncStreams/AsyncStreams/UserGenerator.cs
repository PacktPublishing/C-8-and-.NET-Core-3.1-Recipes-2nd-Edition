using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace AsyncStreams
{
    public static class UserGenerator
    {
        private static HttpClient _http = new HttpClient();
        private static string url = "https://jsonplaceholder.typicode.com/users";

        public async static IAsyncEnumerable<User> GetUser()
        {
            for(int i = 0; i < 10; i++)
            {
                var response = await _http.GetStringAsync($"{url}/{i + 1}");
                var currentUser = JsonSerializer.Deserialize<User>(response, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
                yield return currentUser;
            }
        }
    }
}
