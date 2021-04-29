using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter16.Models
{
    public class UserNameAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
           foreach(char i in value.ToString())
            {
                if (Char.IsNumber(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
