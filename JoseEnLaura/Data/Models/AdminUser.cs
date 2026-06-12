namespace JoseEnLaura.Data.Models;

public enum AdminRole
{
    Standard,
    CeremonyMaster
}

public class AdminUser
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? PasswordHash { get; set; }
    public AdminRole Role { get; set; }
}

