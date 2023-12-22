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

            modelBuilder.Entity<Shop>().HasData(new Shop
            {
                ID = 2,
                ShopName = "Нептун66",
                Url = "https://neptun66.ru"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                ID = 1,
                Name = "Категория"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 1,
                Name = "Зеркало",
                ShopID = 1,
                CategoryID = 1,
                Url = "https://fixsen.ru/product/hotel-zerkalo-kosmeticheskoe-chernoe-d15-fx-31021b/"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 2,
                Name = "Газовый котёл",
                ShopID = 2,
                CategoryID = 1,
                Url= "https://neptun66.ru/catalog/kotly_i_vse_dlya_otopleniya/nastennyy_gazovyy_dvukhkonturnyy_kotel_federica_bugatti_varme_18/"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
