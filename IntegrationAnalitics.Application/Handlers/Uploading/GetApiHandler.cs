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
    private string baseUrl /*= "http://192.168.233.29:30002/api/v3/private/dataRequestTask/"*/;
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
        string result = string.Empty;
        //client.Timeout = TimeSpan.FromMinutes(10);
        //client.MaxResponseContentBufferSize = 29999999;
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

        using HttpClient client = _httpClientFactory.CreateClient();
        int counter = 0;
        if (request.IsPrivate == true)
        {
            baseUrl = "http://192.168.233.29:30002/api/v" + request.ApiVersion + "/private/dataRequestTask/";
        }
        else
        {
            baseUrl = "http://192.168.233.29:30002/api/v" + request.ApiVersion + "/public/dataRequestTask/";
        }

        string askedMethod = request.ApiName;

        string xmlResult;
        string resultNumber = string.Empty;


        string httpRequest = baseUrl + askedMethod;


        var message = new HttpRequestMessage(HttpMethod.Post, httpRequest);
        message.Headers.Add("x-api-key", "C5EFE3F3-FD3B-4FA2-9E54-B0FFCD05646E");
        message.Headers.Add("Connection", "keep-alive");
        //client.MaxResponseContentBufferSize = 29999999;


        using (HttpResponseMessage response = client.SendAsync(message).GetAwaiter().GetResult())
        {
            using (HttpContent content = response.Content)
            {
                do
                {
                    var json = content.ReadAsStringAsync().GetAwaiter().GetResult();
                    resultNumber = String.Empty;
                    for (int i = 10; i < json.Length - 1; i++)
                    {
                        resultNumber += json[i].ToString();
                    }
                    xmlResult = GetXmlData(resultNumber);
                    System.Threading.Thread.Sleep(2000);
                } while ((xmlResult == null || xmlResult == "") && resultNumber.Length == 5);
            }
        }

        //using (var sr = new StreamReader(await resultNumber.Content.ReadAsStreamAsync(), Encoding.GetEncoding("utf-8")))
        //{
        //    xmlResult = sr.ReadToEnd();
        //}

        return new GetApiResponse() { Success = true, ApiXml = xmlResult };

    }
}
