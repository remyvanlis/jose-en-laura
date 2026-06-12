namespace JoseEnLaura.Data.Models;

public class PhotoSession
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<PhotoSessionGuest> Guests { get; set; } = [];
}

public class PhotoSessionGuest
{
    public int Id { get; set; }

    public int PhotoSessionId { get; set; }
    public PhotoSession PhotoSession { get; set; } = null!;
    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!;
}

