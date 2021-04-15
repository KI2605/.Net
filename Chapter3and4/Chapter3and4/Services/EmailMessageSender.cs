using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter3and4.Services
{
    public class EmailMessageSender:IMessageSender
    {
        public string Send()
        {
            return "sent by Email ";
        }
    }
}
