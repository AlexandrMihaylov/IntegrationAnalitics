using IntegrationAnalitics.Application.Domain.Requests.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAnalitics.Controllers;
[Route("/validation/")]
public class ValidationController : Controller
{
    private readonly IMediator _mediator;
    
    public ValidationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// ValidationXml
    /// </summary>
    [HttpGet]
    [Route("validationxml")]
    public async Task<IActionResult> ValidationXml([FromQuery] ValidationXmlRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }
}