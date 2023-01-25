using IntegrationAnalitics.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;

namespace IntegrationAnalitics.Application.Extensions;

public class GetEndpointsHelper : IHostedService
{
    private readonly IEnumerable<EndpointDataSource> _endpointSources;
    /*private readonly IRepository<MethodAccessTypeEntity> _repository;
    private readonly IRepository<MethodWithRoles> _repositoryMid;*/

    public GetEndpointsHelper(IEnumerable<EndpointDataSource> endpointSources/*, IRepository<MethodAccessTypeEntity> repository, IRepository<MethodWithRoles> repositoryMid*/)
    {
        _endpointSources = endpointSources;
        /*_repository = repository;
        _repositoryMid = repositoryMid;*/
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        string[] endpoints = GetEndPoints();
        string[] methodName = new string[endpoints.Length];
        EndpointsOutput(endpoints, methodName);
        return StopAsync(cancellationToken);
    }
    string[] GetEndPoints()
    {
        var endpoints = _endpointSources
            .SelectMany(es => es.Endpoints)
            .OfType<RouteEndpoint>();
        var output = endpoints.Select(e => e.RoutePattern.RawText).ToArray();
        return output;
    }
    string[] EndpointsOutput(string[] endpoints, string[] methodName)
    {
        char searchingElement = '/';
        int searchingElementIndex;
        int iterator = 0;
        foreach (var endpoint in endpoints)
        {

            Console.WriteLine(endpoint);

            searchingElementIndex = endpoint.LastIndexOf(searchingElement);
            methodName[iterator] = endpoint.Substring(searchingElementIndex, endpoint.Length);

            Console.WriteLine(methodName[iterator]);

            iterator++;

        }
        return methodName;
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
