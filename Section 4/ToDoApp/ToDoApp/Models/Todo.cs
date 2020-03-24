using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(192)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public bool Status { get; set; }

        public ICollection<TodoTag> TodoTags { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


    }

}
