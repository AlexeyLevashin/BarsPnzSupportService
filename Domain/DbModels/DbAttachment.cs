namespace Domain.DbModels;

public class DbAttachment
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string StorageKey { get; set; }
    public string ContentType { get; set; }
    public int FileSize { get; set; }
    public int MessageId { get; set; }
    public DbMessage Message { get; set; }
}