using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await foreach(var user in UserGenerator.GetUser())
            {
                Console.WriteLine(user);
            }
        }
    }
}
