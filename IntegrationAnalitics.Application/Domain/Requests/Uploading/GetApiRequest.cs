using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using System.Text.Json.Serialization;

namespace IntegrationAnalitics.Application.Domain.Requests.Uploading;

/// <summary>
/// GetApiRequest
/// </summary>
public class GetApiRequest: BaseRequest, IRequest<GetApiResponse>
{
    private bool isPrivate;
    public string ApiName { get; set; }
    public string ApiVersion { get; set; }
    public bool IsPrivate
    {
        get { return isPrivate; }
        set
        {
            isPrivate = value;

            if (isPrivate)
            { SectionAccess = "/private/"; }
            else
            { SectionAccess = "/public/"; }
        }
    }

    [JsonIgnore]
    public string? SectionAccess { get; set; }
}
