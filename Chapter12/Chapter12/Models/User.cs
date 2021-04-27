using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter12.Models
{
    public class User
    {
        public int Id { get; set; }
        [BindRequired]
        public string Name { get; set; }
        [BindRequired]
        public int Age { get; set; }
        [BindNever]
        public bool HasRight { get; set; }
    }
}
