using Microsoft.EntityFrameworkCore;
using parser.Models.Entities;

namespace parser.Services
{
    public class DBService : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public DBService(DbContextOptions options) : base(options)
        {
        }
    }
}
