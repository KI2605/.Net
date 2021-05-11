using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter21.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан Год Рождения")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Не указан Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
