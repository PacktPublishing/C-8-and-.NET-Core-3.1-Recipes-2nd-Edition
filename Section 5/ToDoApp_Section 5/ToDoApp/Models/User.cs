using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public UserProfile UserProfile { get; set; }

        public ICollection<Todo> Todos { get; set; }

    }
}
