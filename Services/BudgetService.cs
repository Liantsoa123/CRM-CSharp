using Crm_CSharp.Models;

namespace Crm_CSharp.Services;

public class BudgetService
{
    private readonly HttpClient _httpClient;

    public BudgetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    //Obtenir tous les budgets
    public async Task<List<Budget>> GetBudgetsAsync()
    {
        var response = await _httpClient.GetAsync("/api/budgets");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Budget>>();
        }
        return new List<Budget>();
    }
}