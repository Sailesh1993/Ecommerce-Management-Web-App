using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebApi.Domain.src.Entities;

namespace WebApi.WebApi.src.Database
{
    public class DatabaseContext: DbContext
    {
        private readonly IConfiguration _config;
        public DbSet<User> Users { get; set; }
        public DbSet<UserContactDetails> UserContactDetails { get; set; }
        public DbSet<Product> Products {get; set;}
        public DbSet<Order> Orders {get; set; }
        public DbSet<OrderProduct> OrderProducts {get; set;}
        public DbSet<Cart> Carts {get; set;}
        public DbSet<CartItem> CartItem {get; set;}
        public DbSet<Category> Categories {get; set; }

        public DatabaseContext(DbContextOptions options, IConfiguration config):base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlDataSourceBuilder(_config.GetConnectionString("Default"));
            optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}