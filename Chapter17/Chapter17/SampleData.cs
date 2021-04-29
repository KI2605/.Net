using Chapter17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17
{
    public class SampleData
    {
        public static void Initialize(BukoContext db)
        {
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                  new User
                  {
                      NickName = "IhorKolopatin",
                      Password = "26052001",
                      IsAdmin = true
                  },
                  new User
                  {
                      NickName = "RomanObolon",
                      Password = "12345678",
                      IsAdmin = true
                  },
                  new User
                  {
                      NickName = "RimmaBuzuluk",
                      Password = "12345678",
                      IsAdmin = true
                  },
                  new User
                  {
                      NickName = "IvanGroza",
                      Password = "12345678",
                      IsAdmin = true
                  }
                    );

                db.SaveChanges();
            }
           
            
           
        }
    }
}
