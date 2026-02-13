using Domain.DbModels;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Repositories;

public class InstitutionRepository : IInstitutionRepository
{
    private readonly ApplicationContext _context;

    public InstitutionRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddAsync(DbInstitution dbInstitution)
    {
        await _context.Institutions.AddAsync(dbInstitution);
    }

    public void UpdateAsync(DbInstitution dbInstitution)
    {
        _context.Institutions.Update(dbInstitution);
    }

    public void DeleteAsync(DbInstitution dbInstitution)
    {
        _context.Institutions.Remove(dbInstitution);
    }

    public async Task<DbInstitution?> GetByIdAsync(int id)
    {
        return await _context.Institutions.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<DbInstitution?> GetByInnAsync(string inn)
    {
        return await _context.Institutions.FirstOrDefaultAsync(i => i.INN == inn);
    }
}