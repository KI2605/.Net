using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17.Models
{
    public class Service
    {
        private float mark = 0;
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }

        public List<ServiceReview> Reviews { get; set; }

        public float Mark { get { return mark; } set {
                float sum = 0;
                int count = 0;
            foreach(var i in Reviews)
                {
                    sum += i.Mark;
                    count++;
                }
                if (count > 0)
                {
                    mark = sum / count;
                }
                else
                {
                    mark = 0;
                }
            }
            
        }
        public Service()
        {
            Reviews = new List<ServiceReview>();
        }
    }
}
