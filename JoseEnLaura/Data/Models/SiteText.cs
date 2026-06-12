namespace JoseEnLaura.Data.Models;

public class SiteText
{
    public int Id { get; set; }
    
    /// <summary>
    /// Unique key to identify the text, e.g. "hero.pre", "hero.title", "story.text"
    /// </summary>
    public required string Key { get; set; }
    
    /// <summary>
    /// The Dutch text value (can be multi-line)
    /// </summary>
    public required string Value { get; set; }
    
    /// <summary>
    /// The English text value (can be multi-line). Falls back to Dutch if empty.
    /// </summary>
    public string? ValueEn { get; set; }
    
    /// <summary>
    /// Human-friendly label for the admin panel
    /// </summary>
    public required string Label { get; set; }
}

