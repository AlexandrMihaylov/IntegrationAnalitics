using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using MediatR;

namespace IntegrationAnalitics.Application.Domain.Requests.Uploading;

public class GetXmlRequest: BaseRequest, IRequest<GetXmlResponse>
{
    public string Uri { get; set; }
    public string Xml { get; set; }
}