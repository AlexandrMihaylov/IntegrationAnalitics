using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using IntegrationAnalitics.Application.Domain.Responses;
using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualBasic;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAnalitics.Application.Handlers.Uploading;

/// <summary>
/// GetApiHandler
/// </summary>
internal class GetApiHandler : IRequestHandler<GetApiRequest, GetApiResponse>
{
    private readonly string _apiKey = "C5EFE3F3-FD3B-4FA2-9E54-B0FFCD05646E";
    private readonly string _connectionHttp = "keep-alive";
    private readonly string _getDocumentMethod = "/data";
    private readonly string _baseUrl = "http://192.168.233.29:30002/api/";
    private readonly string _sectionPrivate = "/private/";
    private readonly string _sectionPublic = "/public/";
    private readonly string _dataRequestTask = "dataRequestTask/";
    private readonly IHttpClientFactory _httpClientFactory = null!;

    /// <summary>
    /// GetApiHandler
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public GetApiHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentException(nameof(httpClientFactory));
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetApiResponse> Handle(GetApiRequest request, CancellationToken cancellationToken)
    {
        using HttpClient client = _httpClientFactory.CreateClient();

        string url = string.Empty;
        url = _baseUrl + "v" + request.ApiVersion + request.SectionAccess + _dataRequestTask;

        var resultNumber = await GetXmlNumber(client, url, request.ApiName);

        if (resultNumber.TaskId is null)
            return new GetApiResponse { Success = false, Message = "Не получилось запросить номер документа" };

        var xmlResult = await GetXmlData(resultNumber.TaskId.Value, url);

        if (xmlResult is null)
            return new GetApiResponse() { Success = false, Message = "Не получилось собрать документ" };

        return new GetApiResponse() { Success = true, ApiXml = xmlResult };
    }

    private async Task<TaskApiResponse> GetXmlNumber(HttpClient client, string url, string name)
    {
        var message = new HttpRequestMessage(HttpMethod.Post, url + name);
        message.Headers.Add("x-api-key", _apiKey);
        message.Headers.Add("Connection", _connectionHttp);
        TaskApiResponse taskResponse = null;

        using (HttpResponseMessage response = await client.SendAsync(message))
        {
            using (HttpContent content = response.Content)
            {
                var resultContent = await content.ReadAsStringAsync();
                taskResponse = JsonConvert.DeserializeObject<TaskApiResponse>(resultContent);
            }
        }

        return taskResponse;
    }

    /// <summary>
    /// GetXmlData
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private async Task<string> GetXmlData(int id, string url)
    {
        using HttpClient client = _httpClientFactory.CreateClient();

        var message = new HttpRequestMessage();
        message.RequestUri = new Uri(url + id + _getDocumentMethod);
        message.Headers.Add("x-api-key", _apiKey);
        message.Headers.Add("Connection", _connectionHttp);

        string result = string.Empty;
        using (HttpResponseMessage response = await client.SendAsync(message))
        {
            using (HttpContent content = response.Content)
            {
                var json = await content.ReadAsStringAsync();
                result = json;
            }
        }

        return result;
    }
}
