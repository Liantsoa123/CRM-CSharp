using Crm_CSharp.Models;

namespace Crm_CSharp.Services;

public class TicketService
{
    private readonly HttpClient _httpClient;
    
    public TicketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    // Obtenir un ticket par son ID
    public async Task<Ticket> GetTicketByIdAsync(long id)
    {
        var response = await _httpClient.GetAsync($"/api/tickets/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Ticket>();
        }
        return null;
    }
    
    // Obtenir tous les tickets
    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        var response = await _httpClient.GetAsync("/api/tickets");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Ticket>>();
        }
        return new List<Ticket>();
    }
    
    // Supprimer une ticket par son id 
    public async Task<bool> DeleteTicketAsync(long id)
    {
        var response = await _httpClient.DeleteAsync($"/api/tickets/{id}");
        return response.IsSuccessStatusCode;
    }
    
}