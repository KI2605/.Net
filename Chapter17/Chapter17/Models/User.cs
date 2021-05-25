using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17.Models
{
    public class User
    {
        [BindNever]
        public int Id { get; set; }
       // [UserName(ErrorMessage="This userName has being already used")]
        [NotNull]
        public string NickName { get; set; }
       [NotNull]
        public string Password { get; set; }
        [BindNever]
        public bool IsAdmin { get; set; }

        //public List<ServiceReview> ServiceReviews { get; set; }
        //public User()
        //{
        //    ServiceReviews = new List<ServiceReview>();
        //}
    }
}
