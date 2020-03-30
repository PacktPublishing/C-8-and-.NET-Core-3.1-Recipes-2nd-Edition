using System;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var users = await UsersService.GenerateUserNames();
            Console.WriteLine(users);
        }
    }
}
