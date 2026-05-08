using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure
{
    public class ProductClientHubDbContext : DbContext
    {
        // = default!; - NÃO VAI SER NULO
        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\CREAS\\Desktop\\C_Sharp\\RocketSeat\\Curso1 - CSharpEDotNet\\DB\\ProductClientHubDB.db");
        }
    }
}
