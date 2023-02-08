using IntegrationAnalitics.Application.Domain.Requests.Uploading;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAnalitics.Controllers;

/// <summary>
/// UploadingController
/// </summary>
[Route("/uploading/")]
public class UploadingController : Controller
{
    private readonly IMediator _mediator;
    
    public UploadingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// GetSmevText
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getsmevtext")]
    public async Task<IActionResult> GetSmevText([FromQuery] GetXmlRequest request)
    {
        var response = await _mediator.Send(request);

        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }

    /// <summary>
    /// GetApi
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getApi")]
    public async Task<IActionResult> GetApi([FromQuery] GetApiRequest request)
    {
        var response = await _mediator.Send(request);

        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }
}