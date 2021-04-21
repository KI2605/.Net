using ServerUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerUser
{
    public static class SampleData
    {
        public static void Initialize(UserContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                  new User
                  {
                      NickName="IhorKolopatin",
                      Password="26052001",
                      IsAdmin=true
                  },
                  new User
                  {
                       NickName="RomanObolon",
                       Password="12345678",
                       IsAdmin=true
                  },
                  new User
                  {
                      NickName="RimmaBuzuluk",
                      Password="12345678",
                      IsAdmin=true
                  },
                  new User
                  {
                      NickName = "IvanGroza",
                      Password = "12345678",
                      IsAdmin = true
                  }
                    );
                context.SaveChanges();
            }
        }
    }
}
