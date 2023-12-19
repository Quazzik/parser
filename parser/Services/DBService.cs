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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(new Shop
            {
                ID = 1,
                ShopName = "Fixen",
                Url = "https://fixsen.ru"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                ID = 1,
                Name = "Категория"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 1,
                Name = "Товар",
                ShopID = 1,
                CategoryID = 1,
                Url = "https://fixsen.ru/product/hotel-zerkalo-kosmeticheskoe-chernoe-d15-fx-31021b/"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
