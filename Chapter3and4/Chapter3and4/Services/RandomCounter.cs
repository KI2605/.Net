using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter3and4.Services
{
    public class RandomCounter : ICounter
    {
        int _value;
        static Random r = new Random();
        public RandomCounter()
        {
            _value = r.Next(0, 1000000);
        }
      public int Value { get
            {
                return _value;
            } 
        }

    }
}
