using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17.Models
{
    public class LiftReview
    {
        public int Id { get; set; }
        public float Mark { get; set; }
       public int UserId { get; set; }
        public User User { get; set; }
        public int LiftId { get; set; }
        

        
    }
}
