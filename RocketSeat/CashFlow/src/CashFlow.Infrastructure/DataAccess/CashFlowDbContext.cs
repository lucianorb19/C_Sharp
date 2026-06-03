using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;
internal class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);

        var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=root;";
        var serverVersion = new MySqlServerVersion(new Version(8,0,46));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
