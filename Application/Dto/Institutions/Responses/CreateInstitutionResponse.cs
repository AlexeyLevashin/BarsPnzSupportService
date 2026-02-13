namespace Application.Dto.Institutions.Responses;

public class CreateInstitutionResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string INN { get; set; }
    public string? HeadName { get; set; }
    public string? HeadSurname { get; set; }
    public string? HeadPatronymic { get; set; }
}