using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAnalitics.Controllers;

[Route("/uploading/")]
public class UploadingController : Controller
{
    private readonly IMediator _mediator;

    public UploadingController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet]
    [Route("getXml")]
    public async Task<IActionResult> GetXml([FromQuery] GetXmlRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.Success)
            return Ok(response);
        
        return BadRequest(response);
    }
}