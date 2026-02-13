using Domain.Enums;

namespace Domain.DbModels;

public class DbUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymic { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public int? InstitutionId { get; set; }
    public DbInstitution? Institution { get; set; }
}   