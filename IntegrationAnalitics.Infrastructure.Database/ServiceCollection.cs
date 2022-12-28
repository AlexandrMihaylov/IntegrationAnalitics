using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Infrastructure.Database.Context;
using IntegrationAnalitics.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationAnalitics.Infrastructure.Database;

public static class ServiceCollection
{
    public static void AddInfrastructureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var configdb = configuration.GetConnectionString("DBConnection");
        services.AddDbContext<BARSContext>(options => 
            options.UseNpgsql(configdb), ServiceLifetime.Singleton);
        services.AddTransient<IRepository<QA>, QARepository>();
        services.AddTransient<IRepository<Author>, AuthorRepository>();
        services.AddTransient<IRepository<Category>, CategoryRepository>();
    }
}