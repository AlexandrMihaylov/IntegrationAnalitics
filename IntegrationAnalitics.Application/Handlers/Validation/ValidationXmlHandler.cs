using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Application.Domain.Requests.Validation;
using IntegrationAnalitics.Application.Domain.Responses.Validation;
using MediatR;

namespace IntegrationAnalitics.Application.Handlers.Validation;

/// <summary>
/// ValidationXmlHandler
/// </summary>
public class ValidationXmlHandler : IRequestHandler<ValidationXmlRequest, ValidationXmlResponse>
{
    public async Task<ValidationXmlResponse> Handle(ValidationXmlRequest request, CancellationToken cancellationToken)
    {
        XmlSchemaSet schemaSet = new XmlSchemaSet();  
        schemaSet.Add("", XmlReader.Create(new StringReader(request.Xsd)));
        XmlReader rd = XmlReader.Create(new StringReader(request.Xml));  
        XDocument doc = XDocument.Load(rd);
        string result;
        try { doc.Validate(schemaSet, ValidationEventHandler);
            result = "Success"; }
        catch { result = "Error"; }
        static void ValidationEventHandler(object sender, ValidationEventArgs e) {  
             XmlSeverityType type = XmlSeverityType.Warning;  
             if (Enum.TryParse < XmlSeverityType > ("Error", out type)) {  
                 if (type == XmlSeverityType.Error) throw new Exception(e.Message);  
             }  
        } 
        return new ValidationXmlResponse() {Success = true, Result = result};
    }
}