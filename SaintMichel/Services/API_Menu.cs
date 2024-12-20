using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SaintMichel.Services
{
    public class API_Menu
    {
        private readonly HttpClient _httpClient;

        public API_Menu()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CantineMenuItem>> GetMenusWeekAsync(string startDate, string endDate)
        {
            string url = $"https://saintmichel.alwaysdata.net/GetMenusWeek/{startDate}/{endDate}";

            try
            {
                var response = await _httpClient.GetStringAsync(url);
                return JsonSerializer.Deserialize<List<CantineMenuItem>>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<CantineMenuItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'appel API : {ex.Message}");
                return new List<CantineMenuItem>();
            }
        }

        // Méthode pour mettre à jour le contenu d'un menu
        public async Task<bool> UpdateMenuAsync(int idMenu, string contenu)
        {
            string url = $"https://saintmichel.alwaysdata.net/updateMenu/{idMenu}";

            // Créer le corps de la requête
            var payload = new { contenu };

            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Menu {idMenu} mis à jour avec succès.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Erreur lors de la mise à jour du menu {idMenu}: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de connexion pour le menu {idMenu}: {ex.Message}");
                return false;
            }
        }
    }
}
