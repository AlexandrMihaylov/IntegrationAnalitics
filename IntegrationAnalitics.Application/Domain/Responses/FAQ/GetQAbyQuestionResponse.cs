using IntegrationAnalitics.Application.Domain.Entities;

namespace IntegrationAnalitics.Application.Domain.Responses.FAQ;

public class GetQAbyQuestionResponse : BaseResponse
{
    public List<QA> Qas { get; set; }
}