using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter8.Models;
namespace Chapter8
{
    public class SampleData
    {
        public static void Initialize(MobileContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "Iphone X",
                        Company = "Apple",
                        Price = 600
                    },
            new Phone
            {
                Name = "Xiaomi Mi A2",
                Company = "Xiaomi",
                Price = 200
            },
             new Phone
             {
                 Name = "Samsung Galaxy Edge",
                 Company = "Samsung",
                 Price = 550
             }
             );
            }
            context.SaveChanges();
        }
    }
}
