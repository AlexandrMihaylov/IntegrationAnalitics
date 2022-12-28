using IntegrationAnalitics.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace IntegrationAnalitics.Infrastructure.Database.Context;

public class BARSContext : DbContext
{
    public DbSet<QA> QA{ get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }

    public BARSContext(DbContextOptions<BARSContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
    }
}