using IntegrationAnalitics.Application.Domain.Responses.Uploading;
using IntegrationAnalitics.Application.Domain.Enums;
using MediatR;
using Newtonsoft.Json;

namespace IntegrationAnalitics.Application.Domain.Requests.Uploading;

/// <summary>
/// GetXmlRequest
/// </summary>
public class GetXmlRequest: BaseRequest, IRequest<GetXmlResponse>
{
    /// <summary>
    /// Stands
    /// </summary>
    [JsonIgnore]
    public string? Stand { get; set; }
    
    /// <summary>
    /// VersionDocument
    /// </summary>
    public string VersionDocument { get; set; }
    
    /// <summary>
    /// NumberDocument
    /// </summary>
    public string NumberDocument { get; set; }
    
    /// <summary>
    /// TypeDocument
    /// </summary>
    public string TypeDocument { get; set; }
    
    /// <summary>
    /// TypeType
    /// </summary>
    [JsonIgnore]
    public string? TypeType { get; set; }
    
    /// <summary>
    /// CodeSubject
    /// </summary>
    [JsonIgnore]
    public string? CodeSubject { get; set; }
    
    /// <summary>
    /// Time
    /// </summary>
    [JsonIgnore]
    public string? Time { get; set; }
    
    /// <summary>
    /// Base64Format
    /// </summary>
    [JsonIgnore]
    public string? Base64Format { get; set; }
}