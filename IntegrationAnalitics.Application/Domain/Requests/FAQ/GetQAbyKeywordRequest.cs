using IntegrationAnalitics.Application.Domain.Responses.FAQ;
using MediatR;

namespace IntegrationAnalitics.Application.Domain.Requests.FAQ;

public class GetQAbyKeywordsRequest : BaseRequest, IRequest<GetQAbyKeywordsResponse>
{
    public string Keywords { get; set; }
    public int? PageSize { get; set; } = 8;
    public int PageNumber { get; set; }
}