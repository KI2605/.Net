using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter14.Services
{
    public interface ITimeService
    {
        string GetTime();
    }
    public class SimpleTimeService : ITimeService
    {
        public string GetTime()
        {
            return System.DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
