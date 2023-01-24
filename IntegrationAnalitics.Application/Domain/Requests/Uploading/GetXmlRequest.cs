using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using MediatR;

namespace IntegrationAnalitics.Application.Domain.Requests.Uploading;

public class GetXmlRequest: BaseRequest, IRequest<GetXmlResponse>
{
    public string Uri { get; set; }
    public bool IsRelease { get; set; }
    public bool IsBugfix { get; set; }
    public bool IsReserve { get; set; }
    public string VersionDocument { get; set; }
    public string NumberDocument { get; set; }
    public string TypeDocument { get; set; }
    public string TypeType { get; set; }
    public string CodeSubject { get; set; }
    public string Time { get; set; }
    public string Base64Format { get; set; }
}