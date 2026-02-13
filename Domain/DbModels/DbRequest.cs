using Domain.Enums;

namespace Domain.DbModels;

public class DbRequest
{
    public int Id { get; set; }
    public string Theme { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ClosedAt { get; set; }
    public int ClientId { get; set; }
    public int? OperatorId { get; set; }
    public RequestStatus Status { get; set; }
    public Priority Priority { get; set; }
    public DbUser Client { get; set; }
    public DbUser Operator { get; set; }
    
    public List<DbMessage> Messages { get; set; } = new();
}