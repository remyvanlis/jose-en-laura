namespace JoseEnLaura.Data.Models;

public class GeneralNoteComment
{
    public int Id { get; set; }
    
    public int GeneralNoteEntryId { get; set; }
    public GeneralNoteEntry? GeneralNoteEntry { get; set; }
    
    public required string Content { get; set; }
    
    /// <summary>JSON array of AdminUser IDs mentioned via @Name in this comment</summary>
    public string? MentionedUserIds { get; set; }
    
    public int? AttachmentId { get; set; }
    public PlanningAttachment? Attachment { get; set; }
    
    /// <summary>If set, this comment is a reply to another comment</summary>
    public int? ParentCommentId { get; set; }
    public GeneralNoteComment? ParentComment { get; set; }
    public List<GeneralNoteComment> Replies { get; set; } = [];
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public int CreatedById { get; set; }
    public AdminUser? CreatedBy { get; set; }
}

