using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.DTO
{
    public class CreateToDoDTO
    {
        [Required]
        [MinLength(5)]
        [MaxLength(192)]
        public string Title { get; set; }

        public string Description { get; set; }


    }
}
