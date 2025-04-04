using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

public partial class ShopPageViewModel : ObservableObject
{
    private readonly API_Shop _apiShop = new API_Shop();

    [ObservableProperty]
    private ShopItem _selectedItem;

    public ObservableCollection<ShopItem> ShopItems { get; } = new();

    // Commande pour ajouter un article
    [RelayCommand]
    private async Task OnAddShop()
    {
        // Naviguer vers la page AddShopPage pour ajouter un nouvel article
        await Shell.Current.GoToAsync(nameof(AddShopPage));
    }

    // Constructeur
    public ShopPageViewModel()
    {
        LoadShopItemsAsync();
    }
    public async Task RefreshShopItemsAsync()
    {
        try
        {
            var items = await _apiShop.GetAllShopItemsAsync();
            ShopItems.Clear();
            foreach (var item in items)
            {
                ShopItems.Add(item);
            }
        }
        catch (Exception ex)
        {
            // Gérer les erreurs (par exemple, afficher une alerte ou un message dans la console)
            Console.WriteLine($"Erreur lors du rafraîchissement des articles : {ex.Message}");
        }
    }

    // Chargement des articles depuis l'API
    private async Task LoadShopItemsAsync()
    {
        try
        {
            var items = await _apiShop.GetAllShopItemsAsync();
            ShopItems.Clear();
            foreach (var item in items)
            {
                ShopItems.Add(item);
            }
        }
        catch (Exception ex)
        {
            // Gérer les erreurs (logging ou affichage utilisateur)
            Console.WriteLine($"Erreur lors du chargement des articles : {ex.Message}");
        }
    }

    // Commande pour gérer les clics sur les articles
    [RelayCommand]
    private async Task ItemTappedAsync(ShopItem item)
    {
        if (item == null) return;

        try
        {
            // Naviguer vers ShopDetailPage avec l'ID
            await Shell.Current.GoToAsync($"{nameof(ShopDetailPage)}?itemId={item.IdShop}");
        }
        catch (Exception ex)
        {
            // Gérer les erreurs de navigation
            Console.WriteLine($"Erreur lors de la navigation : {ex.Message}");
        }
    }
}
