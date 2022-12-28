using IntegrationAnalitics.Application.Extensions;

namespace IntegrationAnalitics.Application.Domain.Responses;

public class BaseResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public long Timestamp { get; set; } = DateTime.UtcNow.ToUnixTimeMilliseconds();
}