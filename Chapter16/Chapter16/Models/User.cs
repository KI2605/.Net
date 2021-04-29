using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter16.Models
{
    public class User
    {
       [Required][UserName(ErrorMessage ="The Name can't contain a number")]
     public string Name { get; set; }
       // [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [EmailAddress(ErrorMessage ="Uncorrect Email")]
        [Remote(action:"CheckEmail",controller:"Home",ErrorMessage ="This Email is already used")]
        public string Email { get; set; }
        [Required][StringLength(50,MinimumLength =6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="The passwords aren't same")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
        [Range(1,199)]
        public int Age { get; set; }
    }
}
