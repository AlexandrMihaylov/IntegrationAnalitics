using IntegrationAnalitics.Application.Domain.Entities;

namespace IntegrationAnalitics.Application.Domain.Responses.FAQ;

public class GetQAbyAnswerResponse : BaseResponse
{
    public List<QA> Qas { get; set; }
}