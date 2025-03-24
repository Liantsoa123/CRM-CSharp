using System.Net.Http.Json;
using Crm_CSharp.Models.Statistics;

namespace Crm_CSharp.Services;

public class CustomerStatisticsDTOService
{
    private readonly HttpClient _httpClient;

    public CustomerStatisticsDTOService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CustomerStatisticsDTO>> GetCustomerStatisticsAsync()
    {
        var response = await _httpClient.GetAsync("/api/dashboard/customer-statistics");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<CustomerStatisticsDTO>>();
        }
        return new List<CustomerStatisticsDTO>();
    }
}