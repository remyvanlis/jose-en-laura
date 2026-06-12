namespace JoseEnLaura.Data.Models;

public class PlanningAuditLog
{
    public int Id { get; set; }
    public int NoteId { get; set; }
    public PlanningNote? Note { get; set; }
    
    /// <summary>
    /// Action type: created, edited, status_changed, assigned, deadline_set, restored, attachment_added, etc.
    /// </summary>
    public required string Action { get; set; }
    
    /// <summary>
    /// Human-readable description or JSON details of the change
    /// </summary>
    public string? Details { get; set; }
    
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public AdminUser? User { get; set; }
}

