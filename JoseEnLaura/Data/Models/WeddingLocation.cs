namespace JoseEnLaura.Data.Models;

/// <summary>
/// A location card shown in the "Locatie" section of the home page
/// (e.g. Ceremonie / Diner / Feest).
/// </summary>
public class WeddingLocation
{
    public int Id { get; set; }

    /// <summary>
    /// Card title in Dutch, e.g. "Ceremonie".
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// English title. Falls back to Dutch if empty.
    /// </summary>
    public string? TitleEn { get; set; }

    /// <summary>
    /// Icon shown above the title. Stored as an HTML entity or emoji
    /// (e.g. "&#9962;") and rendered as raw markup.
    /// </summary>
    public required string Icon { get; set; }

    /// <summary>
    /// Venue name, e.g. "Kampkuiper".
    /// </summary>
    public required string VenueName { get; set; }

    /// <summary>
    /// First address line, e.g. "Almeloseweg 113, 7615 NA".
    /// </summary>
    public required string AddressLine1 { get; set; }

    /// <summary>
    /// Optional second address line, e.g. "Harbrinkhoek".
    /// </summary>
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// Optional display phone number, e.g. "0546 629 962".
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Display order (lower = first).
    /// </summary>
    public int SortOrder { get; set; }
}

