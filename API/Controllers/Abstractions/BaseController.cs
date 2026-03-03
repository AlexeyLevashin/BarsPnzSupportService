using Domain.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Domain.Enums;

namespace API.Controllers.Abstractions;

[ApiController]
[Authorize]
public abstract class BaseController : ControllerBase
{
    protected Guid UserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) 
                                        ?? throw new UnauthorizedAccessException());
    
    protected UserRole UserRole => Enum.Parse<UserRole>(User.FindFirstValue(ClaimTypes.Role) 
                                                        ?? throw new UnauthorizedAccessException());
    
    protected Guid? InstitutionId
    {
        get
        {
            var claim = User.FindFirstValue("InstitutionId");
            return claim != null ? Guid.Parse(claim) : null;
        }
    }
}