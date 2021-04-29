using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17.Models
{
    public class BukoContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Slope> Slopes { get; set; }
        public DbSet<Lift> Lifts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceReview> ServiceReviews { get; set; }
        public DbSet<LiftReview> LiftReviews { get; set; }
        public BukoContext(DbContextOptions<BukoContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
