using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    public class UsersService
    {
        private static HttpClient _http = new HttpClient();

        public static async Task<IEnumerable<string>> GenerateUserNames()
        {
            var response = await _http.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            var user = new
            {
                Username = String.Empty,
                Name = String.Empty
            };
            var mockUsers = new[] { user };
            var users = JsonConvert.DeserializeAnonymousType(response, mockUsers);
            return users.Select(u => u.Username).ToList();
        }
    }
}
