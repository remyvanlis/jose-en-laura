namespace JoseEnLaura.Data.Models;

public enum BlockType
{
    Text,
    Checkbox,
    Heading,
    Question,
    Important
}

public enum BlockItemStatus
{
    NotStarted,
    InProgress,
    Done,
    Blocked
}

public enum BlockPriority
{
    Low,
    Medium,
    High
}

public class PlanningBlock
{
    public int Id { get; set; }
    public int NoteId { get; set; }
    public PlanningNote? Note { get; set; }
    
    public BlockType Type { get; set; } = BlockType.Text;
    public string Content { get; set; } = "";
    public bool IsChecked { get; set; }
    public int SortOrder { get; set; }
    public int IndentLevel { get; set; }
    
    // Item-level metadata
    public int? AssignedToId { get; set; }
    public AdminUser? AssignedTo { get; set; }
    
    public BlockItemStatus? ItemStatus { get; set; }
    public BlockPriority? Priority { get; set; }
    public DateTime? Deadline { get; set; }
    public bool IsCollapsed { get; set; }
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Attachments
    public int? AttachmentId { get; set; }
    public PlanningAttachment? Attachment { get; set; }
    
    // Comments
    public List<PlanningComment> Comments { get; set; } = [];
}
