using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBlazor.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
    }
}
