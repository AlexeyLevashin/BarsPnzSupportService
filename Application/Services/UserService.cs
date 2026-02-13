using Application.Dto.Institutions.Requests;
using Application.Dto.Users.Responses;
using Application.Interfaces;
using Domain.DbModels;
using Domain.Interfaces;
using Mapster;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;

    public UserService(IUserRepository userRepository, IInstitutionRepository institutionRepository, IUnitOfWork unitOfWork, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _institutionRepository = institutionRepository;
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
    }
    
    public async Task<CreateUserResponse> AddAsync(CreateUseryByAdminRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        
        if (user is not null)
        {
            throw new Exception("Пользователь с данным Email уже существует");
        }

        if (request.InstitutionId != null)
        {
            var institution = await _institutionRepository.GetByIdAsync((int)request.InstitutionId);

            if (institution is null)
            {
                throw new Exception("Учреждение не существует");
            }
        }
    
        var newUser = request.Adapt<DbUser>();
        var password = _passwordService.GeneratePassword();
        newUser.PasswordHash = _passwordService.Hash(password);
        await _userRepository.AddAsync(newUser);
        await _unitOfWork.SaveChangesAsync();
        
        var response = newUser.Adapt<CreateUserResponse>();
        response.InitialPassword = password;
        return response;
    }

    // public Task<DbUser> UpdateAsync(UpdateUserDto updateUserDto)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<DbUser> DeleteAsync(CreateUserDto createUserDto)
    // {
    //     throw new NotImplementedException();
    // }
}