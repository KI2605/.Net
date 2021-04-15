using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter3and4.Services
{
    public class TimeService
    {
        // public string GetTime() => System.DateTime.Now.ToString("hh:mm:ss");
        public TimeService()
        {
            Time = System.DateTime.Now.ToString("hh:mm:ss");
        }
        public string Time { get; }
    }
}
