namespace JoseEnLaura.Data.Models;

public class PlanningCategory
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Icon { get; set; }
    public string? Color { get; set; }
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public List<PlanningNote> Notes { get; set; } = [];
}

