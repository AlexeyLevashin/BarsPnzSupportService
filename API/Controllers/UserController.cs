using API.Controllers.Abstractions;
using Application.Dto.Institutions.Requests;
using Application.Dto.Users.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/users")]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Authorize(Roles = "Operator")]
    public async Task<IActionResult> Add(CreateUseryByAdminRequest request)
    {
        return Ok(await _userService.AddAsync(request));
    }
}