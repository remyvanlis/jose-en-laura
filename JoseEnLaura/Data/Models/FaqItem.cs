namespace JoseEnLaura.Data.Models;

public class FaqItem
{
    public int Id { get; set; }
    
    public required string Question { get; set; }
    
    /// <summary>
    /// English question. Falls back to Dutch if empty.
    /// </summary>
    public string? QuestionEn { get; set; }
    
    /// <summary>
    /// Answer text. Use newlines to separate paragraphs.
    /// </summary>
    public required string Answer { get; set; }
    
    /// <summary>
    /// English answer text. Falls back to Dutch if empty.
    /// </summary>
    public string? AnswerEn { get; set; }
    
    /// <summary>
    /// Display order (lower = first)
    /// </summary>
    public int SortOrder { get; set; }
}

