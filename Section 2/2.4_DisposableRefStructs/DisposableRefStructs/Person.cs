using System;
using System.Collections.Generic;
using System.Text;

namespace DisposableRefStructs
{
    public ref struct Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} / {Email}";
        }

        public void Dispose() { }
    }
}
