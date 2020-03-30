using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deprecated class names: ");
            foreach (var type in GetDeprecatedClassNames())
            {
                Console.WriteLine(type);
            }
        }

        private static IEnumerable<string> GetDeprecatedClassNames()
        {
            var typesWithDeprecatedAttribute = (from a in AppDomain.CurrentDomain.GetAssemblies()
                                               from t in a.GetTypes()
                                               let attr = t.GetCustomAttributes(typeof(DeprecatedAttribute), true)
                                               where attr != null && attr.Length > 0
                                               select t.Name).ToList();
            return typesWithDeprecatedAttribute;
        }
    }
}
