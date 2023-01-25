using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAnalitics.Application.Handlers.Uploading;

internal class GetApiHandler : IRequestHandler<GetApiRequest, GetApiResponse>
{
    public GetApiHandler() 
    {
        
    }
    public async Task<GetApiResponse> Handle(GetApiRequest request, CancellationToken cancellationToken)
    {
        return new GetApiResponse() { Success = true};
    }
}
