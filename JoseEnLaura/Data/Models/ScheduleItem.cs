namespace JoseEnLaura.Data.Models;

public class ScheduleItem
{
    public int Id { get; set; }
    
    /// <summary>
    /// Time label, e.g. "14:00"
    /// </summary>
    public required string Time { get; set; }
    
    /// <summary>
    /// Title, e.g. "Ceremonie"
    /// </summary>
    public required string Title { get; set; }
    
    /// <summary>
    /// English title. Falls back to Dutch if empty.
    /// </summary>
    public string? TitleEn { get; set; }
    
    /// <summary>
    /// Optional description
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// English description. Falls back to Dutch if empty.
    /// </summary>
    public string? DescriptionEn { get; set; }
    
    /// <summary>
    /// Display order (lower = first)
    /// </summary>
    public int SortOrder { get; set; }
    
    /// <summary>
    /// Parent item ID for nested sub-items. Null = top-level item.
    /// </summary>
    public int? ParentId { get; set; }
    
    public ScheduleItem? Parent { get; set; }
    public List<ScheduleItem> Children { get; set; } = [];
}

