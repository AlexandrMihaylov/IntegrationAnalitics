using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using MediatR;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAnalitics.Application.Handlers.Uploading;


internal class GetApiHandler : IRequestHandler<GetApiRequest, GetApiResponse>
{
    private readonly string baseUrl = "http://192.168.233.29:30002/api/v3/public/dataRequestTask/";
    private readonly IHttpClientFactory _httpClientFactory = null!;
    public GetApiHandler(IHttpClientFactory httpClientFactory) 
    {
        _httpClientFactory = httpClientFactory;
    }
    private string GetXmlData(string id) 
    {
        using HttpClient client = _httpClientFactory.CreateClient();
        
        string getMethod = "/data";
        string httpRequest = baseUrl + id + getMethod;
        var message = new HttpRequestMessage();
        message.RequestUri = new Uri(httpRequest);
        message.Headers.Add("x-api-key", "C5EFE3F3-FD3B-4FA2-9E54-B0FFCD05646E");
        message.Headers.Add("Connection", "keep-alive");
        string result;
        using (HttpResponseMessage response = client.SendAsync(message).GetAwaiter().GetResult())
        {
            using (HttpContent content = response.Content)
            {
                var json = content.ReadAsStringAsync().GetAwaiter().GetResult();
                result = json;
            }
        }

        return result;
    }
    public async Task<GetApiResponse> Handle(GetApiRequest request, CancellationToken cancellationToken)
    {
        //try
        //{
            using HttpClient client = _httpClientFactory.CreateClient();
            string askedMethod = request.ApiName;
            string httpRequest = baseUrl + askedMethod;
            var message = new HttpRequestMessage(HttpMethod.Post, httpRequest);
            message.Headers.Add("x-api-key", "C5EFE3F3-FD3B-4FA2-9E54-B0FFCD05646E");
            message.Headers.Add("Connection", "keep-alive");
            string xmlResult;
        using (HttpResponseMessage response = client.SendAsync(message).GetAwaiter().GetResult())
        {
            using (HttpContent content = response.Content)
            {
                string resultNumber = string.Empty;
                var json = content.ReadAsStringAsync().GetAwaiter().GetResult();
                for(int i = 10; i < json.Length-1; i++)
                {
                    resultNumber += json[i].ToString();
                }
                xmlResult = GetXmlData(resultNumber);
            }
        }

        //}
        //catch (Exception e) { Console.WriteLine(e); }
        return new GetApiResponse() { Success = true, ApiXml = xmlResult};
        
    }
}
