using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CRM_CSharp.Models.AlertRate;


namespace Crm_CSharp.Services;

public class AlertRateService
{
    private readonly HttpClient _httpClient;

    public AlertRateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Obtenir un taux d'alerte par son ID
    public async Task<AlertRate> GetAlertRateByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/alert-rate/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<AlertRate>();
        }
        return null;
    }

    // Mettre à jour un taux d'alerte existant
    public async Task<AlertRate> UpdateAlertRateAsync(int id, AlertRate alertRate)
    {
        var response = await _httpClient.PutAsJsonAsync($"/api/alert-rate/{id}", alertRate);
        Console.WriteLine(response.ToString());
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<AlertRate>();
        }
        return null;
    }

    // Obtenir le taux d'alerte actuel (par défaut ou configuré)
    public async Task<double> GetCurrentAlertRateAsync()
    {
        var response = await _httpClient.GetAsync("/api/alert-rate/current");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<double>();
        }
        return 0.2;
    }
}