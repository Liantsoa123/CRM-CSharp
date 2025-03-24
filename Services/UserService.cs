using System.Text.Json;
using Crm_CSharp.Models;

public class UserService
{
    private readonly HttpClient _httpClient;
    
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/users/login?email={email}");
            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    return JsonSerializer.Deserialize<User>(content);
                }
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la connexion: {ex.Message}");
            return null;
        }
    }
}