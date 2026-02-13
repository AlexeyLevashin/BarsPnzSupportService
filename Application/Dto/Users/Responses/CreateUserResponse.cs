using Domain.Enums;

namespace Application.Dto.Users.Responses;

public class CreateUserResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymic { get; set; }
    public string Email { get; set; }
    public string InitialPassword { get; set; }
    public UserRole Role { get; set; }
    public int? InstitutionId { get; set; }
}