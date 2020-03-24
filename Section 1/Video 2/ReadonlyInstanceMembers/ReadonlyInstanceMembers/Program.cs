using System;

namespace ReadonlyInstanceMembers
{
    class Program
    {
        public struct FullAddress
        {
            public readonly string Street;
            public readonly int Number;
            public readonly string PostCode;
            public string PhoneNumber;

            public FullAddress(string street, int number, string postCode, string phoneNumber = "")
            {
                Street = street;
                Number = number;
                PostCode = postCode;
                PhoneNumber = phoneNumber;
            }

            public readonly string GetCombinedAddress()
            {
                //PhoneNumber = "123456789"; <-- Compiler Error due to readonly flag in method
                return $"{Number}, {Street} {PostCode}";
            }
        }

        static void Main(string[] args)
        {
            var address = new FullAddress("Foobar", 42, "12324");
        }
    }
}