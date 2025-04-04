using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

public class API_Shop
{
    private readonly HttpClient _client;

    public API_Shop()
    {
        _client = new HttpClient();
    }

    public async Task<List<ShopItem>> GetAllShopItemsAsync()
    {
        var response = await _client.GetStringAsync("https://saintmichel.alwaysdata.net/GetAllShop");
        return JsonSerializer.Deserialize<List<ShopItem>>(response);
    }

    public async Task<ShopItem> GetShopItemByIdAsync(int id)
    {
        // Utiliser l'URL correcte avec l'ID passé en paramètre
        var response = await _client.GetStringAsync($"https://saintmichel.alwaysdata.net/GetShopById/{id}");

        // Désérialiser la réponse JSON en objet ShopItem
        return JsonSerializer.Deserialize<ShopItem>(response);
    }

    public async Task DeleteShopItemAsync(int itemId)
    {
        // Envoie une requête DELETE à l'URL appropriée
        var response = await _client.DeleteAsync($"https://saintmichel.alwaysdata.net/DeleteShop/{itemId}");

        // Vérifie si la suppression a réussi
        if (response.IsSuccessStatusCode)
        {
            // Logique si la suppression est réussie
            // Par exemple, vous pouvez gérer la réponse ici si nécessaire
        }
        else
        {
            // Gérer l'échec de la suppression, afficher un message d'erreur ou gérer une exception
            throw new Exception($"Erreur lors de la suppression de l'article avec l'ID {itemId}");
        }
    }

    public async Task UpdateShopItemAsync(ShopItem item)
    {
        var json = JsonSerializer.Serialize(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"https://saintmichel.alwaysdata.net/UpdateShop/{item.IdShop}", content);
        if (response.IsSuccessStatusCode)
        {
            // Logique si l'ajout est réussi
            // Par exemple, vous pouvez gérer la réponse ici si nécessaire
        }
        else
        {
            // Gérer l'échec de l'ajout, afficher un message d'erreur ou gérer une exception
            throw new Exception("Erreur lors de l'ajout de l'article");
        }
    }

    public async Task AddShopItemAsync(ShopItem item)
    {
        var json = JsonSerializer.Serialize(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Envoie une requête POST pour ajouter l'article
        var response = await _client.PostAsync("https://saintmichel.alwaysdata.net/AddShop", content);

        // Vérifie si l'ajout a réussi
        if (response.IsSuccessStatusCode)
        {
            // Logique si l'ajout est réussi
            // Par exemple, vous pouvez gérer la réponse ici si nécessaire
        }
        else
        {
            // Gérer l'échec de l'ajout, afficher un message d'erreur ou gérer une exception
            throw new Exception("Erreur lors de l'ajout de l'article");
        }
    }
}
