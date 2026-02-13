using Application.Dto.Institutions.Requests;
using Application.Dto.Users.Responses;
using Domain.DbModels;

namespace Application.Interfaces;

public interface IUserService
{
    public Task<CreateUserResponse> AddAsync(CreateUseryByAdminRequest createUserDto);
    // public Task<DbUser> UpdateAsync(UpdateUserDto updateUserDto);
    // public Task<DbUser> DeleteAsync(CreateUserDto createUserDto);
}