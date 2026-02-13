using Domain.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers.Abstractions;

[ApiController]
[Authorize]
public abstract class BaseController : ControllerBase
{
    protected int UserId
    {
        get
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException();
            }

            return int.Parse(userIdClaim.Value);
        }
    }
}