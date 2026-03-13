using Domain.DbModels;

namespace Domain.Interfaces;

public interface IMessageRepository
{
    public Task CreateAsync(DbMessage message);

}