namespace JoseEnLaura.Data.Models;

public class Play
{
    public int Id { get; set; }
    
    public int AttendanceId { get; set; }
    public Attendance Attendance { get; set; } = null!;
    
    public int DurationMinutes { get; set; }
    public bool NeedsBeamer { get; set; }
    public string? Requirements { get; set; }
}

