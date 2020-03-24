using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace StaticLocalFunction
{
    public class PersonGenerator
    {
        protected static Faker Faker = new Faker();

        public static Person GeneratePerson()
        {
            return new Person()
            {
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
                Email = Faker.Internet.Email()
            };
        }
    }
}
