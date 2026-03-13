using Domain.DbModels;
using Domain.Interfaces;
using Persistence;

namespace Infrastructure.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly ApplicationContext _context;

    public MessageRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(DbMessage message)
    {
        await _context.Messages.AddAsync(message);
    }
}