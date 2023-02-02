using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAnalitics.Application.Domain.Responses.Uploading;

public class GetApiResponse : BaseResponse
{
    public string? ApiXml { get; set; }
}
