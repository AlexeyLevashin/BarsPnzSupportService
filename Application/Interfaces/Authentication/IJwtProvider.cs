using Domain.DbModels;

namespace Application.Interfaces.Authentication;

public interface IJwtProvider
{
    public string GenerateAccessToken(DbUser user);
    public string GenerateRefreshToken();
}