using System;

namespace NullableReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.FirstName = "Foo";
            p.LastName = "Bar";
            p.Email = "foobar@gmail.com";
            Console.WriteLine(p.FirstName);
        }
    }
}
