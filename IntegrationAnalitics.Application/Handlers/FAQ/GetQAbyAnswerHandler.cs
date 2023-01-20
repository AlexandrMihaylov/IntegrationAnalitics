using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Application.Domain.Requests.FAQ;
using IntegrationAnalitics.Application.Domain.Responses.FAQ;
using MediatR;

namespace IntegrationAnalitics.Application.Handlers.FAQ;

public class GetQAbyAnswerHandler: IRequestHandler<GetQAbyAnswerRequest, GetQAbyAnswerResponse>
{
    private readonly IRepository<QA> _repositoryQa;

    public GetQAbyAnswerHandler(IRepository<QA> repositoryQA)
    {
        _repositoryQa = repositoryQA;
    }

    public async Task<GetQAbyAnswerResponse> Handle(GetQAbyAnswerRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Keywords))
        {
            return new GetQAbyAnswerResponse() {Success = false, Message = "Keywords can not be null or empty"};
        }
        
        var resultByKeywords = _repositoryQa
            .Get(x => x.AnswerString
                .Contains(request.Keywords))
            .ToList();
        return new GetQAbyAnswerResponse() {Success = true, Qas = resultByKeywords};
    }
}