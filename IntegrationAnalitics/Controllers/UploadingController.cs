using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using IntegrationAnalitics.Infrastructure.Uploading;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAnalitics.Controllers;
[Route("/uploading/")]
public class UploadingController : Controller
{
    private readonly IMediator _mediator;
    
    public UploadingController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("getsmevtext")]
    public async Task<IActionResult> GetSmevText([FromQuery] GetXmlRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }  
    [HttpGet]
    [Route("downloadSmevXml")]
    public async Task<IActionResult> DownloadSmevXml([FromQuery] DownloadSmevXmlRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.Success)
            return Ok(response);
        
        return BadRequest();
    }
}