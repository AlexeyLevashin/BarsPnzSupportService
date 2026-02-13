using Domain.DbModels;

namespace Domain.Interfaces;

public interface IInstitutionRepository
{
    public Task AddAsync(DbInstitution dbInstitution);
    public void UpdateAsync(DbInstitution dbInstitution);
    public void DeleteAsync(DbInstitution dbInstitution);
    public Task<DbInstitution?> GetByIdAsync(int id);
    public Task<DbInstitution?> GetByInnAsync(string inn);
};
