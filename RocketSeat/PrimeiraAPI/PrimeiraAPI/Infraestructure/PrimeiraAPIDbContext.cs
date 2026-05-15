using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Entities;

namespace PrimeiraAPI.Infraestructure;

public class PrimeiraAPIDbContext : DbContext
{

    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Author> Authors { get; set; } = default!;
    public DbSet<Genre> Genres { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\CREAS\\Desktop\\C_Sharp\\RocketSeat\\PrimeiraAPI\\DB\\Livraria.db");

    }
}
