using Domain.DbModels;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(DbUser dbUser)
    {
        await _context.Users.AddAsync(dbUser);
    }

    public void UpdateAsync(DbUser dbUser)
    {
        _context.Users.Update(dbUser);
    }

    public void DeleteAsync(DbUser dbUser)
    {
        _context.Users.Remove(dbUser);
    }

    public async Task<DbUser?> GetByIdAsync(int userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<DbUser?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}