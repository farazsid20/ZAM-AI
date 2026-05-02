using System.ComponentModel.DataAnnotations;

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
    public string? PlayStoreUrl { get; set; }
    public string? AppStoreUrl { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? LogoURL { get; set; }
    public string FormattedPrice => IsFree ? "FREE" : $"\u20B9{PriceINR:N0}";
    public DateTime CreatedAt { get; set; }
    public bool HasPlayStoreUrl => IsValidExternalUrl(PlayStoreUrl);
    public bool HasAppStoreUrl => IsValidExternalUrl(AppStoreUrl);
    public bool HasMobileApps => HasPlayStoreUrl || HasAppStoreUrl;
    public string PrimaryLogoURL => !string.IsNullOrWhiteSpace(LogoURL) ? LogoURL! : OfficialIconURL;

    public string OfficialIconURL
    {
        get
        {
            if (!TryGetBaseUri(out var baseUri))
            {
                return string.Empty;
            }

            return $"{baseUri}/favicon.ico";
        }
    }

    public string ReliablePublicIconURL
    {
        get
        {
            if (!TryGetBaseUri(out var baseUri))
            {
                return string.Empty;
            }

            return $"https://www.google.com/s2/favicons?sz=128&domain_url={Uri.EscapeDataString(baseUri)}";
        }
    }

    private bool TryGetBaseUri(out string baseUri)
    {
        baseUri = string.Empty;

        if (!Uri.TryCreate(WebsiteURL, UriKind.Absolute, out var uri))
        {
            return false;
        }

        baseUri = $"{uri.Scheme}://{uri.Host}";
        return true;
    }

    public static bool IsValidExternalUrl(string? value)
        => Uri.TryCreate(value, UriKind.Absolute, out var uri) &&
           (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
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
    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Category { get; set; } = string.Empty;

    [Range(0, 999999)]
    public decimal PriceINR { get; set; }

    public bool IsFree { get; set; }

    [Required, ValidExternalUrl]
    public string WebsiteURL { get; set; } = string.Empty;

    [ValidExternalUrl(AllowEmpty = true)]
    public string? PlayStoreUrl { get; set; }

    [ValidExternalUrl(AllowEmpty = true)]
    public string? AppStoreUrl { get; set; }

    [Required, StringLength(400)]
    public string Description { get; set; } = string.Empty;

    [ValidExternalUrl(AllowEmpty = true)]
    public string? LogoURL { get; set; }

    public AIWebsiteDto ToDto(int id, DateTime createdAt)
        => new()
        {
            Id = id,
            Name = Name.Trim(),
            Category = Category.Trim(),
            PriceINR = IsFree ? 0 : PriceINR,
            IsFree = IsFree,
            WebsiteURL = WebsiteURL.Trim(),
            PlayStoreUrl = string.IsNullOrWhiteSpace(PlayStoreUrl) ? null : PlayStoreUrl.Trim(),
            AppStoreUrl = string.IsNullOrWhiteSpace(AppStoreUrl) ? null : AppStoreUrl.Trim(),
            Description = Description.Trim(),
            LogoURL = string.IsNullOrWhiteSpace(LogoURL) ? null : LogoURL.Trim(),
            CreatedAt = createdAt
        };

    public static CreateAIWebsiteDto FromDto(AIWebsiteDto tool)
        => new()
        {
            Name = tool.Name,
            Category = tool.Category,
            PriceINR = tool.PriceINR,
            IsFree = tool.IsFree,
            WebsiteURL = tool.WebsiteURL,
            PlayStoreUrl = tool.PlayStoreUrl,
            AppStoreUrl = tool.AppStoreUrl,
            Description = tool.Description,
            LogoURL = tool.LogoURL
        };
}

public sealed class ValidExternalUrlAttribute : ValidationAttribute
{
    public bool AllowEmpty { get; init; }

    public ValidExternalUrlAttribute()
    {
        ErrorMessage = "Enter a valid http or https URL.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var stringValue = value as string;

        if (string.IsNullOrWhiteSpace(stringValue))
        {
            return AllowEmpty
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage);
        }

        return AIWebsiteDto.IsValidExternalUrl(stringValue)
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage);
    }
}
