using IntegrationAnalitics.Application.Domain.Enums;
using Newtonsoft.Json;

namespace IntegrationAnalitics.Application.Domain.Responses.Uploading;

/// <summary>
/// GetXmlResponse
/// </summary>
public class GetXmlResponse : BaseResponse
{
    /// <summary>
    /// Xml
    /// </summary>
    public string Xml { get; set; }
    
    /// <summary>
    /// Stands
    /// </summary>
    [JsonIgnore]
    //public List<Stand>? Stand { get; set; }
    public string Stand { get; set; }
    
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