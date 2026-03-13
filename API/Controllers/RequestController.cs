using API.Controllers.Abstractions;
using Application.Dto.Requests.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/requests")]
public class RequestController : BaseController
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRequestRequest request)
    {
        return Ok(await _requestService.AddAsync(request, UserId));
    }
}