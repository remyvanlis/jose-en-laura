namespace JoseEnLaura.Data.Models;

public enum CommentImportance
{
    Normal,
    Important,
    Requirement
}

public class PlanningComment
{
    public int Id { get; set; }
    public int BlockId { get; set; }
    public PlanningBlock? Block { get; set; }
    
    public required string Content { get; set; }
    public CommentImportance Importance { get; set; } = CommentImportance.Normal;
    
    /// <summary>JSON array of AdminUser IDs mentioned via @Name in this comment</summary>
    public string? MentionedUserIds { get; set; }
    
    public int? AttachmentId { get; set; }
    public PlanningAttachment? Attachment { get; set; }
    
    /// <summary>If set, this comment is a reply to another comment</summary>
    public int? ParentCommentId { get; set; }
    public PlanningComment? ParentComment { get; set; }
    public List<PlanningComment> Replies { get; set; } = [];
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CreatedById { get; set; }
    public AdminUser? CreatedBy { get; set; }
}

