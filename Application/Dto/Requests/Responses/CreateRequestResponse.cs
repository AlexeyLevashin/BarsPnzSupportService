using Domain.Enums;

namespace Application.Dto.Requests.Responses;

public class CreateRequestResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public RequestStatus Status { get; set; }
}