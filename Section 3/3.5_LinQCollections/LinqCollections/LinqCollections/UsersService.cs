using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace LinqCollections
{
    public class UsersService
    {
        private static string _url = "https://jsonplaceholder.typicode.com/users";
        private static HttpClient _http = new HttpClient();

        public static async Task<IEnumerable<User>> GetUsers()
        {
            var response = await _http.GetStringAsync(_url);
            var users = JsonSerializer.Deserialize<IEnumerable<User>>(response, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            var query = from u in users where u.Username.Contains(".") || u.Username.Contains("_")
                        orderby u.Id
                        select u;
            var filteredUsers = query.ToList();
            return filteredUsers;
        }
    }
}
