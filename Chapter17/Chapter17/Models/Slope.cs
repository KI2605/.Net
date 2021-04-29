using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17.Models
{
    public class Slope
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsWorking { get; set; }
        public string Level { get; set; }
    }
}
