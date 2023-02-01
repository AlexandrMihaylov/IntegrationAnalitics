using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAnalitics.Application.Domain.Responses.Uploading;

namespace IntegrationAnalitics.Application.Domain.Requests.Uploading;

public class GetApiRequest: BaseRequest, IRequest<GetApiResponse>
{
    //public string ApiId { get; set; }
    public string ApiName { get; set; }
    public string ApiVersion { get; set; }
    public bool IsPrivate { get; set; }
}
