namespace JoseEnLaura.Data.Models;

public class Attendance
{
    public int Id { get; set; }
    
    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!;
    
    public bool AttendingCeremony { get; set; }
    public bool AttendingDinner { get; set; }
    public bool AttendingEvening { get; set; }
    
    public string? DietaryNotes { get; set; }
    public string? Message { get; set; }
    
    public DateTime SubmittedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // Check-in timestamps (set when guest physically arrives at each phase)
    public DateTime? CheckedInCeremonyAt { get; set; }
    public DateTime? CheckedInDinnerAt { get; set; }
    public DateTime? CheckedInPartyAt { get; set; }
    
    public Play? Play { get; set; }
}

