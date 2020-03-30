using System;
using System.Threading.Tasks;

namespace LinqCollections
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var users = await UsersService.GetUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Username}");
            }
        }
    }
}
