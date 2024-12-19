using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SaintMichel.Services
{
    public class API_Menu
    {
        private readonly HttpClient _client;

        public API_Menu()
        {
            _client = new HttpClient();
        }

        // Obtenir tous les menus
        public async Task<List<CantineMenuItem>> GetAllMenusAsync()
        {
            var response = await _client.GetStringAsync("https://saintmichel.alwaysdata.net/GetAllMenus");
            return JsonSerializer.Deserialize<List<CantineMenuItem>>(response);
        }

        // Obtenir les menus pour une période donnée
        public async Task<List<CantineMenuItem>> GetMenusForWeekAsync(string start, string end)
        {
            var response = await _client.GetStringAsync($"https://saintmichel.alwaysdata.net/GetMenusWeek/{start}/{end}");
            return JsonSerializer.Deserialize<List<CantineMenuItem>>(response);
        }

        // Ajouter un plat
        public async Task AddMenuItemAsync(CantineMenuItem item)
        {
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://saintmichel.alwaysdata.net/AddMenu", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erreur lors de l'ajout du plat");
            }
        }

        // Mettre à jour un plat
        public async Task UpdateMenuItemAsync(int id, CantineMenuItem item)
        {
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"https://saintmichel.alwaysdata.net/UpdateMenu/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        // Supprimer un plat
        public async Task DeleteMenuItemAsync(int id)
        {
            var response = await _client.DeleteAsync($"https://saintmichel.alwaysdata.net/DeleteMenu/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erreur lors de la suppression du plat avec l'ID {id}");
            }
        }
    }
}
