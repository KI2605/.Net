using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17.Models
{
    public class User
    {
        [BindNever]
        public int Id { get; set; }
       // [UserName(ErrorMessage="This userName has being already used")]
        public string NickName { get; set; }
        public string Password { get; set; }
        [BindNever]
        public bool IsAdmin { get; set; }


    }
}
