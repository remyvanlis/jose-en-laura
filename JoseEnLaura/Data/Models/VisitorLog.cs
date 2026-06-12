namespace JoseEnLaura.Data.Models;

public class VisitorLog
{
    public int Id { get; set; }
    public DateTime VisitedAt { get; set; } = DateTime.UtcNow;
}

