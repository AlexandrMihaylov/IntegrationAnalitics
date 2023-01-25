using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAnalitics.Application.Domain.Responses.Uploading;

internal class GetApiResponse : BaseResponse
{
    public List<string>? Api { get; set; }
}
