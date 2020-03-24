using System;
using System.Collections.Generic;

namespace StaticLocalFunction
{
    public class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();
            for (int i =0; i < 10; i++)
            {
                var person = PersonGenerator.GeneratePerson();
                persons.Add(person);
            }
            var emailProvider = "gmail";
            static Predicate<Person> FilterProviderFactory(string emailProvider)
            {
                return p => p.Email.Contains(emailProvider);
            }
            var filteredUsers = persons.FindAll(FilterProviderFactory(emailProvider));
            foreach (var user in filteredUsers)
            {
                Console.WriteLine(user);
            }
        }
    }
}
