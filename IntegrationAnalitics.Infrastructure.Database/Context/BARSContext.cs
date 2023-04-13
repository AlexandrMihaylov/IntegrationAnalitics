using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Application.Domain.Entities.Planning;
using Microsoft.EntityFrameworkCore;
namespace IntegrationAnalitics.Infrastructure.Database.Context;

public class BARSContext : DbContext
{
    public DbSet<QA> QA{ get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PokerPlan> PokerPlans { get; set; }
    public DbSet<TaskPokerPlan> TaskPokerPlans { get; set; }

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