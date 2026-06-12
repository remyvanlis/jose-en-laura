namespace JoseEnLaura.Data.Models;

public class GeneralNoteEntry
{
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public string? MentionedUserIds { get; set; }
    
    public int? AttachmentId { get; set; }
    public PlanningAttachment? Attachment { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CreatedById { get; set; }
    public AdminUser? CreatedBy { get; set; }
    
    public List<GeneralNoteComment> Comments { get; set; } = [];
}

