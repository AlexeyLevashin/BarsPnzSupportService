using Application.Dto.Messages.Requests;
using Domain.DbModels;

namespace Application.Interfaces;

public interface IMessageService
{
    public Task<DbMessage> AddAsync(CreateMessageRequest request);
}