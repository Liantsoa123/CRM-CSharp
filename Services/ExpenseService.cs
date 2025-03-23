using System.Net.Http.Json;
using Crm_CSharp.Models;

namespace Crm_CSharp.Services;

public class ExpenseService
{
    private readonly HttpClient _httpClient;

    public ExpenseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Obtenir une dépense par son ID
    public async Task<Expense> GetExpenseByIdAsync(long id)
    {
        var response = await _httpClient.GetAsync($"/api/expenses/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Expense>();
        }
        return null;
    }

    // Obtenir toutes les dépenses
    public async Task<List<Expense>> GetAllExpensesAsync()
    {
        var response = await _httpClient.GetAsync("/api/expenses");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Expense>>();
        }
        return new List<Expense>();
    }

    // Créer une nouvelle dépense
    public async Task<Expense> CreateExpenseAsync(Expense expense)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/expenses/create", expense);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Expense>();
        }
        return null;
    }

    // Mettre à jour une dépense existante
    public async Task<Expense> UpdateExpenseAsync(long id, Expense expense)
    {
        var response = await _httpClient.PutAsJsonAsync($"/api/expenses/{id}", expense);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Expense>();
        }
        return null;
    }

    // Supprimer une dépense
    public async Task<bool> DeleteExpenseAsync(long id)
    {
        var response = await _httpClient.DeleteAsync($"/api/expenses/{id}");
        return response.IsSuccessStatusCode;
    }

    // Obtenir les dépenses pour un budget spécifique
    public async Task<List<Expense>> GetExpensesByBudgetAsync(long budgetId)
    {
        var response = await _httpClient.GetAsync($"/api/expenses/budget/{budgetId}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Expense>>();
        }
        return new List<Expense>();
    }
}
