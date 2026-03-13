using Domain.Enums;

namespace Application.Dto.Messages.Requests;

public class CreateFirstMessageRequest
{
    public string? Text { get; set; }
}