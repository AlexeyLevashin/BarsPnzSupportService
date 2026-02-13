using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.DbModels;

public class DbMessage
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public MessageType Type { get; set; }
    public int SenderId { get; set; }
    public int RequestId { get; set; }
    public DbUser Sender { get; set; }
    public DbRequest Request { get; set; }
    public List<DbAttachment> Attachments { get; set; } = new();
}