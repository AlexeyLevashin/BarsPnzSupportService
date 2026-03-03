namespace Domain.DbModels;

public class DbInstitution
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; }
    public string INN { get; set; }
    public string? HeadName { get; set; }
    public string? HeadSurname { get; set; }
    public string? HeadPatronymic { get; set; }
    public List<DbUser> Users { get; set; } = new();
}