using IntegrationAnalitics.Application.Domain.Requests;
using IntegrationAnalitics.Application.Domain.Requests.FAQ;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAnalitics.Controllers;

[Route("/faq/")]
public class FaqController : Controller
{
    private readonly IMediator _mediator;

    public FaqController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet]
    [Route("getQAbyKeywords")]
    public async Task<IActionResult> GetQAbyKeywords([FromQuery] GetQAbyKeywordsRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.Success)
            return Ok(response);
        
        return BadRequest(response);
    }
}