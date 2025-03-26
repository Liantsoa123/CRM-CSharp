using System.Net.Http.Headers;
using System.Text;

namespace Crm_CSharp.Services;

public class ImportService
{
    private readonly HttpClient _httpClient;

    public ImportService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ImportJsonFileAsync(IFormFile file)
    {
        try
        {
            // Lire le contenu du fichier
            using var reader = new StreamReader(file.OpenReadStream());
            var jsonContent = await reader.ReadToEndAsync();

            // Créer le contenu de la requête
            var content = new StringContent(
                jsonContent,
                Encoding.UTF8,
                "application/json"
            );

            // Envoyer la requête
            var response = await _httpClient.PostAsync("/api/import/duplicate", content);
            
            // Log pour le debug
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
            
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'importation: {ex.Message}");
            return false;
        }
    }
}