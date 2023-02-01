using IntegrationAnalitics.Application.Domain.Requests.Uploading;
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
        Console.WriteLine(response.Xml);
        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpGet]
    [Route("/uploading/getApi")]
    public async Task<IActionResult> GetApi([FromQuery] GetApiRequest request)
    {
        var response = await _mediator.Send(request);
        Console.WriteLine(response.ApiXml);
        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpGet]
    [Route("test")]
    //https://localhost:7067/getXml?uri=''&xml=''
    public async Task<IActionResult> Test()
    {
        return BadRequest();
    }
}