using System.Net.Http.Json;
using System.Text.Json;
using ZamAiMart.Client.Models;

namespace ZamAiMart.Client.Services;

public class ApiService
{
    private readonly HttpClient _http;
    private static readonly JsonSerializerOptions _opts = new() { PropertyNameCaseInsensitive = true };

    private bool? _apiReachable;
    public bool IsOfflineMode => _apiReachable == false;

    public ApiService(HttpClient http) { _http = http; }

    // ── Categories ──────────────────────────────────────────────────────────
    public async Task<List<CategoryDto>> GetCategoriesAsync()
    {
        if (_apiReachable == false) return StaticData.GetCategories();
        try
        {
            var result = await _http.GetFromJsonAsync<List<CategoryDto>>("api/categories", _opts);
            if (result?.Count > 0) { _apiReachable = true; return result; }
            _apiReachable = false;
            return StaticData.GetCategories();
        }
        catch { _apiReachable = false; return StaticData.GetCategories(); }
    }

    // ── AI Websites ─────────────────────────────────────────────────────────
    public async Task<List<AIWebsiteDto>> GetAllWebsitesAsync()
    {
        if (_apiReachable == false) return StaticData.GetAll();
        try
        {
            var result = await _http.GetFromJsonAsync<List<AIWebsiteDto>>("api/aiwebsites", _opts);
            if (result?.Count > 0) { _apiReachable = true; return result; }
            _apiReachable = false;
            return StaticData.GetAll();
        }
        catch { _apiReachable = false; return StaticData.GetAll(); }
    }

    public async Task<List<AIWebsiteDto>> GetWebsitesByCategoryAsync(string category)
    {
        if (_apiReachable == false) return StaticData.GetByCategory(category);
        try
        {
            var result = await _http.GetFromJsonAsync<List<AIWebsiteDto>>(
                $"api/aiwebsites?category={Uri.EscapeDataString(category)}", _opts);
            if (result != null) { _apiReachable = true; return result; }
            return StaticData.GetByCategory(category);
        }
        catch { return StaticData.GetByCategory(category); }
    }

    public async Task<AIWebsiteDto?> GetWebsiteByIdAsync(int id)
    {
        if (_apiReachable == false) return StaticData.GetById(id);
        try
        {
            var result = await _http.GetFromJsonAsync<AIWebsiteDto>($"api/aiwebsites/{id}", _opts);
            _apiReachable = true;
            return result;
        }
        catch { return StaticData.GetById(id); }
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
}
