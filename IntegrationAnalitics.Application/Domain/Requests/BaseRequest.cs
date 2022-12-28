using System.Text.Json.Serialization;
using IntegrationAnalitics.Application.Extensions;

namespace IntegrationAnalitics.Application.Domain.Requests;

public class BaseRequest
{
    [JsonIgnore]
    public long Timestamp { get; set; } = DateTime.UtcNow.ToUnixTimeMilliseconds();
}