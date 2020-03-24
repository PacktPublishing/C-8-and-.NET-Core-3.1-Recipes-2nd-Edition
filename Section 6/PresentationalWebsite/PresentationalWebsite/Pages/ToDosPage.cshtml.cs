using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using PresentationalWebsite.Models;

namespace PresentationalWebsite
{
    public class ToDosPageModel : PageModel
    {
        protected HttpClient _http = new HttpClient();

        public IEnumerable<ToDo> ToDos { get; set; }

        public async Task OnGet()
        {
            var response = await _http.GetStringAsync("http://jsonplaceholder.typicode.com/todos");
            ToDos = JsonSerializer.Deserialize<IEnumerable<ToDo>>(response, new JsonSerializerOptions()
            { 
                PropertyNameCaseInsensitive = true
            });
        }
    }
}