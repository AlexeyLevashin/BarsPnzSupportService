using Application.Dto.Requests.Requests;
using Application.Dto.Requests.Responses;
using Domain.DbModels;

namespace Application.Interfaces;

public interface IRequestService
{
    public Task<CreateRequestResponse> AddAsync(CreateRequestRequest request, Guid userId);
}