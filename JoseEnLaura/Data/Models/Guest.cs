namespace JoseEnLaura.Data.Models;

public enum InvitedForType
{
    Ceremony,            // Only ceremony
    Evening,             // Only evening party
    CeremonyAndEvening,  // Ceremony + evening (but not full day guest)
    DayGuest             // Full day: ceremony + dinner + evening
}

public class Guest
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public InvitedForType InvitedFor { get; set; }
    
    public Attendance? Attendance { get; set; }
}

