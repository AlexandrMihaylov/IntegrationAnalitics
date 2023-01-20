using IntegrationAnalitics.Application.Domain.Entities;

namespace IntegrationAnalitics.Application.Domain.Responses.FAQ;

public class GetQAbyKeywordsResponse : BaseResponse
{
    public List<QA> Qas { get; set; }
}