using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Application.Domain.Requests.FAQ;
using IntegrationAnalitics.Application.Domain.Responses.FAQ;
using MediatR;

namespace IntegrationAnalitics.Application.Handlers.FAQ;

public class GetQAByQuestionHandler : IRequestHandler<GetQAbyQuestionRequest, GetQAbyQuestionResponse>
{
    private readonly IRepository<QA> _repositoryQa;

    public GetQAByQuestionHandler(IRepository<QA> repositoryQA)
    {
        _repositoryQa = repositoryQA;
    }

    public async Task<GetQAbyQuestionResponse> Handle(GetQAbyQuestionRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Keywords))
        {
            return new GetQAbyQuestionResponse() {Success = false, Message = "Keywords can not be null or empty"};
        }
        
        var resultByKeywords = _repositoryQa
            .Get(x => x.QuestionString
                .Contains(request.Keywords))
            .ToList();
        return new GetQAbyQuestionResponse() {Success = true, Qas = resultByKeywords};
    }
}