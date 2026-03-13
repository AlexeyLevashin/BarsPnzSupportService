using Application.Dto.Authorization.Requests;
using Application.Dto.Authorization.Responses;
using Application.Dto.Users.Responses;

namespace Application.Interfaces;

public interface IAuthService
{
    public Task<LoginSuccessResponse> LoginAsync(LoginRequest request);
    public Task<LoginSuccessResponse> RegisterAsync(RegisterRequest request);
    public Task<LoginSuccessResponse> RefreshTokenAsync(RefreshRequest request);

}