using JoseEnLaura.Data.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace JoseEnLaura.Components.Shared.Planning;

public static class PlanningHelpers
{
    // ...existing @mentions helper section...
    
    /// <summary>
    /// Parses comment text for @Name patterns and returns a list of matching AdminUser IDs.
    /// </summary>
    public static List<int> ExtractMentionedUserIds(string text, List<AdminUser> adminUsers)
    {
        if (string.IsNullOrWhiteSpace(text) || adminUsers.Count == 0) return [];
        var ids = new List<int>();
        // Match @Name patterns (case-insensitive)
        foreach (var user in adminUsers)
        {
            if (Regex.IsMatch(text, $@"@{Regex.Escape(user.Name)}\b", RegexOptions.IgnoreCase))
            {
                ids.Add(user.Id);
            }
        }
        return ids.Distinct().ToList();
    }

    /// <summary>
    /// Serializes mention IDs to JSON string for storage.
    /// </summary>
    public static string? SerializeMentionIds(List<int> ids) =>
        ids.Count == 0 ? null : JsonSerializer.Serialize(ids);

    /// <summary>
    /// Deserializes mention IDs from JSON string.
    /// </summary>
    public static List<int> DeserializeMentionIds(string? json)
    {
        if (string.IsNullOrWhiteSpace(json)) return [];
        try { return JsonSerializer.Deserialize<List<int>>(json) ?? []; }
        catch { return []; }
    }

    /// <summary>
    /// Renders comment text with @Name mentions as highlighted spans.
    /// </summary>
    public static string RenderMentions(string text, List<AdminUser> adminUsers)
    {
        if (string.IsNullOrWhiteSpace(text) || adminUsers.Count == 0) return text;
        var result = System.Web.HttpUtility.HtmlEncode(text);
        foreach (var user in adminUsers.OrderByDescending(u => u.Name.Length))
        {
            result = Regex.Replace(result, $@"@{Regex.Escape(user.Name)}\b",
                $"<span class=\"mention\">@{System.Web.HttpUtility.HtmlEncode(user.Name)}</span>",
                RegexOptions.IgnoreCase);
        }
        return result.Replace("\n", "<br />");
    }

    /// <summary>
    /// Returns a human-friendly relative time string in Dutch.
    /// </summary>
    public static string GetRelativeTime(DateTime utcTime)
    {
        var diff = DateTime.UtcNow - utcTime;
        if (diff.TotalMinutes < 1) return "zojuist";
        if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes}m geleden";
        if (diff.TotalHours < 24) return $"{(int)diff.TotalHours}u geleden";
        if (diff.TotalDays < 7) return $"{(int)diff.TotalDays}d geleden";
        if (diff.TotalDays < 30) return $"{(int)(diff.TotalDays / 7)}w geleden";
        return utcTime.ToLocalTime().ToString("dd MMM yyyy");
    }
    public static string GetBlockTypeIcon(PlanningBlock block) => block.Type switch
    {
        BlockType.Checkbox => block.IsChecked ? "?" : "?",
        BlockType.Heading => "H",
        BlockType.Question => "?",
        BlockType.Important => "!",
        _ => "📝"
    };

    public static string GetBlockPlaceholder(BlockType type) => type switch
    {
        BlockType.Heading => "Heading...",
        BlockType.Checkbox => "Taak...",
        BlockType.Question => "Stel een vraag...",
        BlockType.Important => "Belangrijk punt...",
        _ => "Type hier, of gebruik / voor commando's..."
    };

    public static string GetStatusColor(NoteStatus status) => status switch
    {
        NoteStatus.NotStarted => "#94a3b8",
        NoteStatus.InProgress => "#3b82f6",
        NoteStatus.Done => "#22c55e",
        NoteStatus.NeedsAttention => "#f59e0b",
        _ => "#94a3b8"
    };

    public static string GetStatusLabel(NoteStatus status) => status switch
    {
        NoteStatus.NotStarted => "Niet gestart",
        NoteStatus.InProgress => "Bezig",
        NoteStatus.Done => "Klaar",
        NoteStatus.NeedsAttention => "Aandacht nodig",
        _ => status.ToString()
    };

    public static string GetItemStatusIcon(BlockItemStatus status) => status switch
    {
        BlockItemStatus.NotStarted => "?",
        BlockItemStatus.InProgress => "??",
        BlockItemStatus.Done => "?",
        BlockItemStatus.Blocked => "??",
        _ => ""
    };

    public static string GetItemStatusLabel(BlockItemStatus status) => status switch
    {
        BlockItemStatus.NotStarted => "Niet gestart",
        BlockItemStatus.InProgress => "Bezig",
        BlockItemStatus.Done => "Klaar",
        BlockItemStatus.Blocked => "Geblokkeerd",
        _ => ""
    };

    public static string GetPriorityLabel(BlockPriority priority) => priority switch
    {
        BlockPriority.Low => "Laag",
        BlockPriority.Medium => "Normaal",
        BlockPriority.High => "Hoog",
        _ => ""
    };

    public static string GetPriorityIcon(BlockPriority priority) => priority switch
    {
        BlockPriority.Low => "??",
        BlockPriority.Medium => "??",
        BlockPriority.High => "??",
        _ => ""
    };

    public static string GetCommentImportanceLabel(CommentImportance importance) => importance switch
    {
        CommentImportance.Normal => "Normaal",
        CommentImportance.Important => "Belangrijk",
        CommentImportance.Requirement => "Vereiste",
        _ => "Normaal"
    };

    public static string GetCommentImportanceCss(CommentImportance importance) => importance switch
    {
        CommentImportance.Important => "comment-important",
        CommentImportance.Requirement => "comment-requirement",
        _ => ""
    };

    public static (int Done, int Total, int Percent) GetNoteProgress(PlanningNote note)
    {
        var trackable = note.Blocks.Where(b => b.Type == BlockType.Checkbox || b.ItemStatus.HasValue).ToList();
        if (trackable.Count == 0) return (0, 0, 0);
        var done = trackable.Count(b => b.IsChecked || b.ItemStatus == BlockItemStatus.Done);
        var pct = (int)Math.Round(done * 100.0 / trackable.Count);
        return (done, trackable.Count, pct);
    }

    public static string GetAuditIcon(string action) => action switch
    {
        "created" => "??",
        "edited" => "??",
        "status_changed" => "??",
        "assigned" => "??",
        "deadline_set" => "??",
        "deadline_removed" => "??",
        "restored" => "??",
        "attachment_added" => "??",
        "comment_added" => "??",
        _ => "??"
    };

    public static string GetAuditActionText(string action) => action switch
    {
        "created" => "heeft deze notitie aangemaakt",
        "edited" => "heeft wijzigingen opgeslagen",
        "status_changed" => "heeft de status gewijzigd",
        "assigned" => "heeft de toewijzing gewijzigd",
        "deadline_set" => "heeft een deadline ingesteld",
        "deadline_removed" => "heeft de deadline verwijderd",
        "restored" => "heeft een eerdere versie hersteld",
        "attachment_added" => "heeft een bijlage toegevoegd",
        "comment_added" => "heeft een reactie geplaatst",
        _ => action
    };

    public static string TruncateText(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text)) return "(leeg)";
        return text.Length <= maxLength ? text : text[..maxLength] + "…";
    }
}

