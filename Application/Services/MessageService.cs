using Application.Dto.Messages.Requests;
using Application.Interfaces;
using Domain.DbModels;

namespace Application.Services;

public class MessageService : IMessageService
{
    public Task<DbMessage> AddAsync(CreateMessageRequest request)
    {
        throw new NotImplementedException();
    }
}