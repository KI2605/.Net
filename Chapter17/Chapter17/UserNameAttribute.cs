using Chapter17.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17
{
    public class UserNameAttribute : ValidationAttribute
    {
        BukoContext db;
        //public UserNameAttribute( BukoContext context)
        //{
        //    db = context;
        //}
        public override bool IsValid(object value)
        {
            foreach (var i in db.Users)
            {
                if (value.ToString() == i.NickName)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
