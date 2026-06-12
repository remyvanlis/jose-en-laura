namespace JoseEnLaura.Data.Models;

public enum NoteStatus
{
    NotStarted,
    InProgress,
    Done,
    NeedsAttention
}

public class PlanningNote
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public PlanningCategory? Category { get; set; }
    
    public required string Title { get; set; }
    public int SortOrder { get; set; }
    public NoteStatus Status { get; set; } = NoteStatus.NotStarted;
    
    public int? AssignedToId { get; set; }
    public AdminUser? AssignedTo { get; set; }
    
    public DateTime? Deadline { get; set; }
    
    /// <summary>If true, this note is shown as pinned info card at top of overview</summary>
    public bool IsPinnedInfo { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CreatedById { get; set; }
    public AdminUser? CreatedBy { get; set; }
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public int UpdatedById { get; set; }
    public AdminUser? UpdatedBy { get; set; }
    
    public int CurrentVersion { get; set; } = 1;
    
    public List<PlanningBlock> Blocks { get; set; } = [];
    public List<PlanningNoteVersion> Versions { get; set; } = [];
    public List<PlanningAuditLog> AuditLogs { get; set; } = [];
}

