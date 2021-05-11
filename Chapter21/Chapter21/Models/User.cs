using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter21.Models
{
    public class User
    {
        [BindNever]
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        public string Password { get; set; }
        public int Year { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }

    }
}
