using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter8.Models
{
    public class MobileContext : DbContext
    {
        // свойства DBset соотносятся с таблицами в базах данных
        
        //получаем набор обьектов Phone
        public DbSet<Phone> Phones { get; set; }

        //получаем набор обьектов Order
        public DbSet<Order> Orders { get; set; }
        public MobileContext(DbContextOptions<MobileContext> options) : base (options)
        {
            // по умолчанию база данных отсутствует, создаем ее, если она уже есть, ничего не произойдет
            Database.EnsureCreated();

        }
    }
}
