using System;

namespace DisposableRefStructs
{
    class Program
    {
        static void Main(string[] args)
        {
            using var person = PersonGenerator.GeneratePerson();
            Console.WriteLine(person.ToString());
        }
    }
}
