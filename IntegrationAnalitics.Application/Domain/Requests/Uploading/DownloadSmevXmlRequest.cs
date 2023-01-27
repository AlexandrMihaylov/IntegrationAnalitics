using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using MediatR;

namespace IntegrationAnalitics.Application.Domain.Requests.Uploading;

public class DownloadSmevXmlRequest : BaseRequest, IRequest<DownloadSmevXmlResponse>
{
    public string VersionDocument { get; set; }
    public string NumberDocument { get; set; }
    public string TypeDocument { get; set; }
}