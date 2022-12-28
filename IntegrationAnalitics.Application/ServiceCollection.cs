using System.Reflection;
using AutoMapper;
using IntegrationAnalitics.Application.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationAnalitics.Application;

public static class ServiceCollection 
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollection).GetTypeInfo().Assembly;
        services.AddMediatR(assembly);
            
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}