using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public  DbSet<booking> bookings { get; set; }
        public  DbSet<customer> customers { get; set; }
        public  DbSet<guid> guids { get; set; }
        public  DbSet<Trip> Trips { get; set; }
        public  DbSet<opin> opins { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Transportaion> Transportaions { get; set; }


    }
}
