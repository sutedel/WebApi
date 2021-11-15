using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);
            modelBuilder.Entity<Order>().HasMany(c => c.Products);
            modelBuilder.Entity<Order>().HasOne(c => c.User);
            modelBuilder.Entity<User>().HasMany(c => c.Orders).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            modelBuilder.Seed();

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet <User>Users { get; set; }

    }
}
