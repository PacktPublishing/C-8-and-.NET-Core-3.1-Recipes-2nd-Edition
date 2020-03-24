using System;
using System.IO;

namespace UsingDeclarations
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("helloworld.txt");
            var contents = reader.ReadLine();
            Console.WriteLine(contents);
        }
    }
}
