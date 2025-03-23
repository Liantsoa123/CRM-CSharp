using Crm_CSharp.Models;

namespace Crm_CSharp.Services;

public class LeadService
{
    private readonly HttpClient _httpClient;

    public LeadService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    // Obtenir un lead par son ID
    public async Task<Lead> GetLeadByIdAsync(long id)
    {
        var response = await _httpClient.GetAsync($"/api/leads/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Lead>();
        }
        return null;
    }
    
    
    // Obtenir tous les leads
    public async Task<List<Lead>> GetAllLeadsAsync()
    {
        var response = await _httpClient.GetAsync("/api/leads");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Lead>>();
        }
        return new List<Lead>();
    }
    
}