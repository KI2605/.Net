using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chap22.Models
{
    public class User:IdentityUser
    {
        public int Year { get; set; }
    }
}
