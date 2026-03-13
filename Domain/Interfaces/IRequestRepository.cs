using Domain.DbModels;

namespace Domain.Interfaces;

public interface IRequestRepository
{
    public Task CreateAsync(DbRequest request);
}