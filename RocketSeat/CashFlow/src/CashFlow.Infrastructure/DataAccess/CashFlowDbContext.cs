using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;
public class CashFlowDbContext : DbContext
{

    //DbContextOptions options É ATRIBUITO PARA O CONSTRUTOR DA CLASSE BASE DESTA
    //QUE NESSE CASO É A CLASSE DbContext
    public CashFlowDbContext(DbContextOptions options) : base(options){}

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }

    //SOBRESCRITA - MUDAR NOME TABELA Tag PARA Tags
    //TABELA Tags SEM DbSet. ELA É CRIADA PQ EM Expenses HÁ O ATRIBUTO Tags
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tag>().ToTable("Tags");
    }
}
