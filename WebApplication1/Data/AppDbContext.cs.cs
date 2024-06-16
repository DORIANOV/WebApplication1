using BeerSupplyAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace BeerSupplyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Keg> Kegs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
