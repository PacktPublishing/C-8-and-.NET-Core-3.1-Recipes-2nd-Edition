using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDosDesktop.Models;

namespace ToDosDesktop.Services
{
    public class ToDosService
    {
        protected HttpClient _http = new HttpClient();

        public async Task<IEnumerable<ToDo>> GetToDos()
        {
            return JsonSerializer.Deserialize<IEnumerable<ToDo>>(await _http.GetStringAsync("http://jsonplaceholder.typicode.com/todos"), new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
