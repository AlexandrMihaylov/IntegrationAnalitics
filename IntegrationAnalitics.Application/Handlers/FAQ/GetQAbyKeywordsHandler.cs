using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Application.Domain.Requests.FAQ;
using IntegrationAnalitics.Application.Domain.Responses.FAQ;
using MediatR;

namespace IntegrationAnalitics.Application.Handlers.FAQ;

public class GetQAbyKeywordsHandler : IRequestHandler<GetQAbyKeywordsRequest, GetQAbyKeywordsResponse>
{
    private readonly IRepository<QA> _repositoryQa;

    public GetQAbyKeywordsHandler(IRepository<QA> repositoryQA)
    {
        _repositoryQa = repositoryQA;
    }

    public async Task<GetQAbyKeywordsResponse> Handle(GetQAbyKeywordsRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Keywords))
        {
            return new GetQAbyKeywordsResponse() {Success = false, Message = "Keywords can not be null or empty"};
        }
        
        var resultByKeywords = _repositoryQa
            .Get(x => x.Keywords
                .Contains(request.Keywords))
            .ToList();
        return new GetQAbyKeywordsResponse() {Success = true, Qas = resultByKeywords};
    }
}