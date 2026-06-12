namespace JoseEnLaura.Data.Models;

public class UserBlockVisit
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    public AdminUser? User { get; set; }
    
    public int BlockId { get; set; }
    public PlanningBlock? Block { get; set; }
    
    public DateTime LastVisitedAt { get; set; } = DateTime.UtcNow;
}

