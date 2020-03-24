using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class TodoTag
    {
        public Todo Todo { get; set; }
        public int TodoId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }

    }
}
