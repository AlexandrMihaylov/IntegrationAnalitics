using IntegrationAnalitics.Application.Domain.Responses.Validation;
using MediatR;

namespace IntegrationAnalitics.Application.Domain.Requests.Validation;

public class ValidationXmlRequest: BaseRequest, IRequest<ValidationXmlResponse>
{
    /// <summary>
    /// Xsd
    /// </summary>
    public string Xsd { get; set; }
    
    /// <summary>
    /// Xml
    /// </summary>
    public string Xml { get; set; }
}