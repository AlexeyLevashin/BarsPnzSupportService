using Application.Authentication;
using Application.Dto.Authorization.Requests;
using Application.Dto.Authorization.Responses;
using Application.Interfaces;
using Application.Interfaces.Authentication;
using Domain.DbModels;
using Domain.Enums;
using Domain.Interfaces;
using Mapster;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
    private readonly IJwtProvider _jwtProvider;
    private readonly JwtOptions _jwtOptions;
    private readonly IDistributedCache _cache;

    public AuthService(IUserRepository userRepository, IInstitutionRepository institutionRepository, IUnitOfWork unitOfWork, IPasswordService passwordService, IJwtProvider jwtProvider, IOptions<JwtOptions> jwtOptions, IDistributedCache cache)
    {
        _userRepository = userRepository;
        _institutionRepository = institutionRepository;
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
        _jwtProvider = jwtProvider;
        _jwtOptions = jwtOptions.Value;
        _cache = cache;
    }

    public async Task<LoginSuccessResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user is null || !_passwordService.Verify(request.Password, user.PasswordHash))
        {
            throw new Exception("Неверный логин или пароль");
        }

        var accessToken = _jwtProvider.GenerateAccessToken(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();

        await SaveRefreshTokenToRedis(user.Id, refreshToken);
        
        return new LoginSuccessResponse
        {
            AccessToken = accessToken, RefreshToken = refreshToken
        };
    }

    public async Task<LoginSuccessResponse> RegisterAsync(RegisterRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user is not null)
        {
            throw new Exception("Пользователь с данным Email уже существует в системе");
        }

        if (request.InstitutionId != null)
        {
            var institution = await _institutionRepository.GetByIdAsync((Guid)request.InstitutionId);
            if (institution is null)
            {
                throw new Exception("Данного учреждения не существует в системе");
            }
        }

        var newUser = request.Adapt<DbUser>();
        newUser.PasswordHash = _passwordService.Hash(request.Password);
        newUser.Role = UserRole.User; 
        await _userRepository.AddAsync(newUser);
        await _unitOfWork.SaveChangesAsync();

        var accessToken = _jwtProvider.GenerateAccessToken(newUser);
        var refreshToken = _jwtProvider.GenerateRefreshToken();

        await SaveRefreshTokenToRedis(newUser.Id, refreshToken);
        
        return new LoginSuccessResponse
        {
            AccessToken = accessToken, 
            RefreshToken = refreshToken
        };
    }

    private async Task SaveRefreshTokenToRedis(Guid userId, string refreshToken)
    {
        var key = $"rt:{refreshToken}";

        await _cache.SetStringAsync(
            key,
            userId.ToString(),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(_jwtOptions.RefreshTokenExpiresDays)
            });
    }
}