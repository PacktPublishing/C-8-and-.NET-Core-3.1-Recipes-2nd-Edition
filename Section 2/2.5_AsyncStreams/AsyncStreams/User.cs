using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncStreams
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Email}";
        }
    }
}
