using BarberShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infrastructure.DataAccess;
internal class BarberShopDbContext : DbContext
{

    //DbContextOptions options É ATRIBUITO PARA O CONSTRUTOR DA CLASSE BASE DESTA
    //QUE NESSE CASO É A CLASSE DbContext
    public BarberShopDbContext(DbContextOptions option) : base(option) {}

    public DbSet<Billing> Billings { get; set; }
}
