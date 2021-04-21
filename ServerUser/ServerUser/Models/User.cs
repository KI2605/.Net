using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerUser.Models
{
    public class User
    {
        [Key]
        public string NickName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get;set; }
    }
}
