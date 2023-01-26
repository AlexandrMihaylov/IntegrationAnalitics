using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using MediatR;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAnalitics.Application.Handlers.Uploading;


internal class GetApiHandler : IRequestHandler<GetApiRequest, GetApiResponse>
{
    private readonly IEnumerable<EndpointDataSource> _endpointSources;
    private readonly string baseUrl = "http://192.168.233.29:30002/api/v3/public/dataRequestTask/";
    private readonly IHttpClientFactory _httpClientFactory = null!;
    public GetApiHandler(IHttpClientFactory httpClientFactory) 
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<GetApiResponse> Handle(GetApiRequest request, CancellationToken cancellationToken)
    {
        //try
        //{
            using HttpClient client = _httpClientFactory.CreateClient();
            string askedMethod = request.ApiName;
            string httpRequest = baseUrl + askedMethod;
            var message = new HttpRequestMessage();
            message.RequestUri = new Uri(httpRequest);
            message.Headers.Add("x-api-key", "C5EFE3F3-FD3B-4FA2-9E54-B0FFCD05646E");
            message.Headers.Add("Connection", "keep-alive");
            var result = await client.SendAsync(message);
            string response = String.Empty;
            using (var sr = new StreamReader(await result.Content.ReadAsStreamAsync(), Encoding.GetEncoding("utf-8")))
            {
                response = sr.ReadToEnd();
            }
        //}
        //catch (Exception e) { Console.WriteLine(e); }
        return new GetApiResponse() { Success = true, ApiXml = null };
        
    }
}
