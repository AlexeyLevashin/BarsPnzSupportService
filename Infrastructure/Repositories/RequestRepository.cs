using Domain.DbModels;
using Domain.Interfaces;
using Persistence;

namespace Infrastructure.Repositories;

public class RequestRepository : IRequestRepository
{
    private readonly ApplicationContext _context;

    public RequestRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(DbRequest request)
    {
        await _context.Requests.AddAsync(request);
    }
}