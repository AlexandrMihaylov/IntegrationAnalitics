using System.Text;
using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using MediatR;

namespace IntegrationAnalitics.Application.Handlers.FAQ;

public class GetXmlHandler : IRequestHandler<GetXmlRequest, GetXmlResponse>
{
    private readonly IHttpClientFactory _httpClientFactory = null!;
    public GetXmlHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GetXmlResponse> Handle(GetXmlRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Xml))
        {
            return new GetXmlResponse() {Success = false, Message = "Keywords can not be null or empty"};
        }
        using HttpClient client = _httpClientFactory.CreateClient(); //using var client = new HttpClient();
        var message = new HttpRequestMessage();
        message.Content = new StringContent(request.Xml);
        client.BaseAddress = new Uri(request.Uri);
        var result = await client.SendAsync(message);
        string response;
        using (var sr = new StreamReader(await result.Content.ReadAsStreamAsync(), Encoding.GetEncoding("utf-8")))
        {
            response = sr.ReadToEnd();
        }
        return new GetXmlResponse() {Success = true, Xml = response};
    }
}