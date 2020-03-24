using System;
using System.Collections.Generic;

namespace NullCoalescingOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> namesList = null;
            (namesList ??= new List<string>()).Add("John");
            Console.WriteLine(string.Join(",", namesList));

            int? a = null;
            a ??= 8;
            Console.WriteLine(a);
        }
    }
}
