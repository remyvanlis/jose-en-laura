namespace JoseEnLaura.Data.Models;

public class ContactInfo
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Phone { get; set; }
    
    public required string Email { get; set; }
    
    /// <summary>
    /// Display order (lower = first)
    /// </summary>
    public int SortOrder { get; set; }
}

