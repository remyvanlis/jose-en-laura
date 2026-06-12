namespace JoseEnLaura.Data.Models;

public class SiteImage
{
    public int Id { get; set; }
    
    /// <summary>
    /// Human-friendly name, e.g. "Hero achtergrond"
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Slot identifier that maps to a location on the site, e.g. "hero-bg", "photo-strip-1", "full-photo"
    /// </summary>
    public required string Slot { get; set; }
    
    /// <summary>
    /// Original file name of the uploaded image
    /// </summary>
    public required string FileName { get; set; }
    
    /// <summary>
    /// Content type, e.g. "image/jpeg", "image/png"
    /// </summary>
    public required string ContentType { get; set; }
    
    /// <summary>
    /// The image data stored as a byte array
    /// </summary>
    public required byte[] Data { get; set; }
}

