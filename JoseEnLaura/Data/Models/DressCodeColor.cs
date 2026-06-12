namespace JoseEnLaura.Data.Models;

/// <summary>
/// A single colour swatch shown in the dress-code section. Manageable from the admin panel.
/// </summary>
public class DressCodeColor
{
    public int Id { get; set; }

    /// <summary>
    /// Hex colour value, e.g. "#EFD3D0".
    /// </summary>
    public required string Hex { get; set; }

    /// <summary>
    /// Dutch label, e.g. "Blush".
    /// </summary>
    public required string NameNl { get; set; }

    /// <summary>
    /// Optional English label.
    /// </summary>
    public string? NameEn { get; set; }

    public int SortOrder { get; set; }
}

