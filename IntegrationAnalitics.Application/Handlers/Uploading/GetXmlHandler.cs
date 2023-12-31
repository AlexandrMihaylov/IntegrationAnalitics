﻿using System.Reflection.Metadata;
using System.Text;
using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Application.Domain.Enums;
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
   
    /// <summary>
    /// GetXmlHandler
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public GetXmlHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentException(nameof(httpClientFactory));
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetXmlResponse> Handle(GetXmlRequest request, CancellationToken cancellationToken)
    {
        _xmlTemplate = _xmlTemplate
            .Replace(_TAG_VERSION, request.VersionDocument)
            .Replace(_TAG_DOCUMENTNUMBER, request.NumberDocument)
            .Replace(_TAG_DOCUMENTTYPE, request.TypeDocument);

        using HttpClient client = _httpClientFactory.CreateClient();

        var message = new HttpRequestMessage();
        message.Content = new StringContent(_xmlTemplate);

        client.BaseAddress = new Uri("https://unp.bars.group/release/api/smev");
        var result = await client.SendAsync(message);

        string response = string.Empty;
        using (var sr = new StreamReader(await result.Content.ReadAsStreamAsync(), Encoding.GetEncoding("utf-8")))
        {
            response = sr.ReadToEnd();
        }

        //request.Stand = request.Stand.ToList();
        //List<Stand> stand = new List<Stand>();
        //stand[0] = request.Stand[0];
        //stand[1] = request.Stand[1];
        //stand[2] = request.Stand[2];
        string asd = request.CodeSubject;
        
        bool a = request.Stand.Contains('0');
        bool b = request.Stand.Contains('1');
        bool c = request.Stand.Contains('2');
        string stand = a.ToString() + b.ToString() + c.ToString();  
        return new GetXmlResponse() {Success = true, Xml = response,
            TypeType = request.TypeType,
            Stand = stand,
            //Stand = request.Stand,
            CodeSubject = request.CodeSubject, Time = request.Time, Base64Format = request.Base64Format};
    }
}