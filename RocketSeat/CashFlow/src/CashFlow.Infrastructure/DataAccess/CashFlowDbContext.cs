using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;
internal class CashFlowDbContext : DbContext
{

    //DbContextOptions options É ATRIBUITO PARA O CONSTRUTOR DA CLASSE BASE DESTA
    //QUE NESSE CASO É A CLASSE DbContext
    public CashFlowDbContext(DbContextOptions options) : base(options){}

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }
}
