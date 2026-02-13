using Domain.DbModels;

namespace Domain.Interfaces;

public interface IUserRepository
{
    public Task AddAsync(DbUser dbUser);
    public void UpdateAsync(DbUser dbUser);
    public void DeleteAsync(DbUser dbUser);
    public Task<DbUser?> GetByIdAsync(int userId);
    public Task<DbUser?> GetByEmailAsync(string email);
}