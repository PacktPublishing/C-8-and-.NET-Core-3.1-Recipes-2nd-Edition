using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefaultInterfaceMethods
{
    public interface IErrorHandler
    {
        Task LogError(Exception ex)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Error Thrown: {ex.Message}");
            });
        }
    }
}
