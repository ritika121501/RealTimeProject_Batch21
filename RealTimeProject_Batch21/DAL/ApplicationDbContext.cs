using Microsoft.EntityFrameworkCore;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
    }
}
