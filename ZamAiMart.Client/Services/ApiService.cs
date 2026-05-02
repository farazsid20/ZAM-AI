using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;
using ZamAiMart.Client.Models;

namespace ZamAiMart.Client.Services;

public class ApiService
{
    private const string CustomToolsStorageKey = "zam-ai-mart.custom-tools";

    private readonly HttpClient _http;
    private readonly IJSRuntime _js;
    private static readonly JsonSerializerOptions _opts = new() { PropertyNameCaseInsensitive = true };

    private bool? _apiReachable;
    public bool IsOfflineMode => _apiReachable == false;

    public ApiService(HttpClient http, IJSRuntime js)
    {
        _http = http;
        _js = js;
    }

    // ── Categories ──────────────────────────────────────────────────────────
    public async Task<List<CategoryDto>> GetCategoriesAsync()
    {
        List<CategoryDto> categories;

        if (_apiReachable == false)
        {
            categories = StaticData.GetCategories();
        }
        else
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<CategoryDto>>("api/categories", _opts);
                if (result?.Count > 0)
                {
                    _apiReachable = true;
                    categories = result;
                }
                else
                {
                    _apiReachable = false;
                    categories = StaticData.GetCategories();
                }
            }
            catch
            {
                _apiReachable = false;
                categories = StaticData.GetCategories();
            }
        }

        var mergedTools = await GetAllWebsitesAsync();
        var categoryNames = categories
            .Select(c => c.CategoryName)
            .Concat(mergedTools.Select(t => t.Category))
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(name => name)
            .ToList();

        return categoryNames.Select((name, index) => new CategoryDto
        {
            Id = index + 1,
            CategoryName = name
        }).ToList();
    }

    // ── AI Websites ─────────────────────────────────────────────────────────
    public async Task<List<AIWebsiteDto>> GetAllWebsitesAsync()
    {
        var baseTools = await LoadBaseWebsitesAsync();
        var customTools = await GetStoredCustomToolsAsync();
        return MergeTools(baseTools, customTools);
    }

    public async Task<List<AIWebsiteDto>> GetWebsitesByCategoryAsync(string category)
    {
        var all = await GetAllWebsitesAsync();
        return all.Where(x => x.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<AIWebsiteDto?> GetWebsiteByIdAsync(int id)
    {
        var all = await GetAllWebsitesAsync();
        return all.FirstOrDefault(x => x.Id == id);
    }

    // ── Helpers for homepage sections ───────────────────────────────────────
    public async Task<List<AIWebsiteDto>> GetFeaturedAsync(int count = 8)
    {
        var all = await GetAllWebsitesAsync();
        return all.Take(count).ToList();
    }

    public async Task<List<AIWebsiteDto>> GetLatestAsync(int count = 12)
    {
        var all = await GetAllWebsitesAsync();
        return all.OrderByDescending(x => x.CreatedAt).Take(count).ToList();
    }

    public async Task<List<AIWebsiteDto>> SearchAsync(string query)
    {
        var all = await GetAllWebsitesAsync();
        return all.Where(w =>
            w.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            w.Description.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            w.Category.Contains(query, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public async Task<int> SaveWebsiteAsync(int? existingId, CreateAIWebsiteDto input)
    {
        var all = await GetAllWebsitesAsync();
        var existing = existingId.HasValue
            ? all.FirstOrDefault(t => t.Id == existingId.Value)
            : null;

        var id = existing?.Id ?? (all.Count == 0 ? 1 : all.Max(t => t.Id) + 1);
        var createdAt = existing?.CreatedAt ?? DateTime.UtcNow;

        var customTools = await GetStoredCustomToolsAsync();
        customTools.RemoveAll(t => t.Id == id);
        customTools.Add(input.ToDto(id, createdAt));

        await SaveStoredCustomToolsAsync(customTools);
        return id;
    }

    private async Task<List<AIWebsiteDto>> LoadBaseWebsitesAsync()
    {
        if (_apiReachable == false)
        {
            return StaticData.GetAll();
        }

        try
        {
            var result = await _http.GetFromJsonAsync<List<AIWebsiteDto>>("api/aiwebsites", _opts);
            if (result?.Count > 0)
            {
                _apiReachable = true;
                return result;
            }

            _apiReachable = false;
            return StaticData.GetAll();
        }
        catch
        {
            _apiReachable = false;
            return StaticData.GetAll();
        }
    }

    private static List<AIWebsiteDto> MergeTools(List<AIWebsiteDto> baseTools, List<AIWebsiteDto> customTools)
    {
        var merged = baseTools.ToDictionary(tool => tool.Id);

        foreach (var customTool in customTools)
        {
            merged[customTool.Id] = customTool;
        }

        return merged.Values
            .OrderBy(t => t.Name)
            .ToList();
    }

    private async Task<List<AIWebsiteDto>> GetStoredCustomToolsAsync()
    {
        try
        {
            var stored = await _js.InvokeAsync<string?>("browserStore.get", CustomToolsStorageKey);
            if (string.IsNullOrWhiteSpace(stored))
            {
                return new List<AIWebsiteDto>();
            }

            return JsonSerializer.Deserialize<List<AIWebsiteDto>>(stored, _opts) ?? new List<AIWebsiteDto>();
        }
        catch
        {
            return new List<AIWebsiteDto>();
        }
    }

    private Task SaveStoredCustomToolsAsync(List<AIWebsiteDto> tools)
    {
        var payload = JsonSerializer.Serialize(tools, _opts);
        return _js.InvokeVoidAsync("browserStore.set", CustomToolsStorageKey, payload).AsTask();
    }
}
