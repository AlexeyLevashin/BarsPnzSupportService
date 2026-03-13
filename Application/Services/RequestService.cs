using Application.Dto.Requests.Requests;
using Application.Dto.Requests.Responses;
using Application.Interfaces;
using Domain.DbModels;
using Domain.Enums;
using Domain.Interfaces;
using Mapster;

namespace Application.Services;

public class RequestService : IRequestService
{
    private readonly IRequestRepository _requestRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public RequestService(IRequestRepository requestRepository, IMessageRepository messageRepository,
        IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _requestRepository = requestRepository;
        _messageRepository = messageRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }
    
    public async Task<CreateRequestResponse> AddAsync(CreateRequestRequest request, Guid userId)
    {
        var dbRequest = request.Adapt<DbRequest>();
        var dbMessage = request.Message.Adapt<DbMessage>();
        dbRequest.Status = RequestStatus.New;
        dbRequest.ClientId = userId;
        dbMessage.Type = MessageType.Public;
        dbMessage.RequestId = dbRequest.Id;
        dbMessage.SenderId = userId;
        
        dbRequest.Messages.Add(dbMessage);
        await _requestRepository.CreateAsync(dbRequest);
        await _unitOfWork.SaveChangesAsync();

        return new CreateRequestResponse
        {
            Id = dbRequest.Id,
            CreatedAt = dbRequest.CreatedAt,
            Status = dbRequest.Status
        };
    }
}