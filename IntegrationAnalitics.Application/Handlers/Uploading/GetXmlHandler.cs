using System.Text;
using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using MediatR;

namespace IntegrationAnalitics.Application.Handlers.Uploading;

public class GetXmlHandler : IRequestHandler<GetXmlRequest, GetXmlResponse>
{
    private string _TAG_VERSION = "__VERSION__";
    private string _TAG_DOCUMENTNUMBER = "__DOCUMENTNUMBER__";
    private string _TAG_DOCUMENTTYPE = "__DOCUMENTTYPE__";
    private string _xmlTemplate = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><UNPDocument xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"urn://x-artefacts-minfin-unp/__VERSION__\"> <DocumentNumber>__DOCUMENTNUMBER__</DocumentNumber> <DocumentType>__DOCUMENTTYPE__</DocumentType> <CreateNew>true</CreateNew> </UNPDocument>";
    private readonly IHttpClientFactory _httpClientFactory = null!;
    public GetXmlHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GetXmlResponse> Handle(GetXmlRequest request, CancellationToken cancellationToken)
    {
        _xmlTemplate = _xmlTemplate.Replace(_TAG_VERSION, request.VersionDocument);
        _xmlTemplate = _xmlTemplate.Replace(_TAG_DOCUMENTNUMBER, request.NumberDocument);
        _xmlTemplate = _xmlTemplate.Replace(_TAG_DOCUMENTTYPE, request.TypeDocument);

        using HttpClient client = _httpClientFactory.CreateClient();
        var message = new HttpRequestMessage();
        message.Content = new StringContent(_xmlTemplate);
        client.BaseAddress = new Uri("https://unp.bars.group/release/api/smev");//Uri
        var result = await client.SendAsync(message);
        string response;
        using (var sr = new StreamReader(await result.Content.ReadAsStreamAsync(), Encoding.GetEncoding("utf-8")))
        {
            response = sr.ReadToEnd();
        }
        return new GetXmlResponse() {Success = true, Xml = response};
    }
}