namespace JoseEnLaura.Data.Models;

public class UserNoteVisit
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    public AdminUser? User { get; set; }
    
    public int NoteId { get; set; }
    public PlanningNote? Note { get; set; }
    
    public DateTime LastVisitedAt { get; set; } = DateTime.UtcNow;
}

