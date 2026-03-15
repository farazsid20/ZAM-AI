namespace ZamAiMart.Client.Models;

/// <summary>Matches the AIWebsiteDto returned by /api/aiwebsites</summary>
public class AIWebsiteDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal PriceINR { get; set; }
    public bool IsFree { get; set; }
    public string WebsiteURL { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? LogoURL { get; set; }
    public string FormattedPrice => IsFree ? "FREE" : $"₹{PriceINR:N0}";
    public DateTime CreatedAt { get; set; }
}

/// <summary>Matches the CategoryDto returned by /api/categories</summary>
public class CategoryDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    // Computed helpers for the UI
    public string Icon => CategoryName switch
    {
        var n when n.Contains("Chatbot") => "💬",
        var n when n.Contains("Image") => "🎨",
        var n when n.Contains("Video") => "🎬",
        var n when n.Contains("Code") => "💻",
        var n when n.Contains("Writing") => "✍️",
        var n when n.Contains("Voice") || n.Contains("Audio") => "🎙️",
        var n when n.Contains("Music") => "🎵",
        var n when n.Contains("Business") => "📈",
        var n when n.Contains("Productivity") => "⚡",
        var n when n.Contains("Design") => "🖌️",
        _ => "🤖"
    };
}

public class CreateAIWebsiteDto
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal PriceINR { get; set; }
    public bool IsFree { get; set; }
    public string WebsiteURL { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? LogoURL { get; set; }
}
