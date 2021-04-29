using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17.Models
{
    public class ServiceReview
    {

        public int Id { get; set; }
        //public int UserId{get;set;}
        //public User User { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
       
        public string? Review { get; set; }

        public float Mark { get; set; }
    }
}
