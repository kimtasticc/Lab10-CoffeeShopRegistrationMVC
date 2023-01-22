using Microsoft.EntityFrameworkCore;
using Lab10CoffeeShopRegistrationMVC.Models;

namespace Lab10CoffeeShopRegistrationMVC.DataAccessLayer
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext()
        {

        }

        public CoffeeShopContext(DbContextOptions options) : base(options) 
        { 

        }

        public DbSet<ProductViewModel> Products { get; set; }

        private static IConfigurationRoot _configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                string cnstr = _configuration.GetConnectionString("CoffeeShopDb");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
    }
}


