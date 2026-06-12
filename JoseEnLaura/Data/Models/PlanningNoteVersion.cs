namespace JoseEnLaura.Data.Models;

public class PlanningNoteVersion
{
    public int Id { get; set; }
    public int NoteId { get; set; }
    public PlanningNote? Note { get; set; }
    
    public int VersionNumber { get; set; }
    
    /// <summary>
    /// JSON snapshot of the note title + all blocks at this version
    /// </summary>
    public required string SnapshotJson { get; set; }
    
    public string? Title { get; set; }
    public NoteStatus Status { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CreatedById { get; set; }
    public AdminUser? CreatedBy { get; set; }
}

