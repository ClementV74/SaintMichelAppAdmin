using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

public partial class ShopPageViewModel : ObservableObject
{
    private readonly API_Shop _apiShop = new API_Shop();

    [ObservableProperty]
    private ShopItem selectedItem;

    public ObservableCollection<ShopItem> ShopItems { get; } = new();

    public ShopPageViewModel()
    {
        LoadShopItemsAsync();
    }

    [RelayCommand]
    private async Task AddShopAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddShopPage));
    }

    [RelayCommand]
    private async Task ItemTappedAsync(ShopItem item)
    {
        if (item == null)
            return;

        try
        {
            await Shell.Current.GoToAsync($"{nameof(ShopDetailPage)}?itemId={item.IdShop}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la navigation : {ex.Message}");
        }
    }

    [RelayCommand]
    public async Task RefreshShopItemsAsync()
    {
        await LoadShopItemsAsync();
    }

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
            Console.WriteLine($"Erreur lors du chargement des articles : {ex.Message}");
        }
    }
}
