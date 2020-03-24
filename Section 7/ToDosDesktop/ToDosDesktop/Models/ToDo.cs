using System;
using System.Collections.Generic;
using System.Text;

namespace ToDosDesktop.Models
{
    public class ToDo
    {
        public string Title { get; set; }
        public int Id { get; set; }

        public bool Completed { get; set; }
        public int UserId { get; set; }
    }
}
