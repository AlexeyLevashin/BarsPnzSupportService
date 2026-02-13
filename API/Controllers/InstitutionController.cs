using API.Controllers.Abstractions;
using Application.Dto.Institutions.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/institutions")]
public class InstitutionController : BaseController
{
    private IInstitutionService _institutionService;

    public InstitutionController(IInstitutionService institutionService)
    {
        _institutionService = institutionService;
    }

    [HttpPost]
    [Authorize(Roles = "Operator")]
    public async Task<IActionResult> Add(CreateInstitutionRequest request)
    {
        return Ok(await _institutionService.AddAsync(request));
    }
}