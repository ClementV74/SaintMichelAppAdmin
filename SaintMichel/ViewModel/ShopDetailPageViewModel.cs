using System.Windows.Input;
using Microsoft.Maui.Controls;

public class ShopDetailPageViewModel : BindableObject
{
    private ShopItem _selectedItem;
    private readonly API_Shop _apiShop = new API_Shop();

    public ShopItem SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }

    public ShopDetailPageViewModel(int itemId)
    {
        LoadShopItemDetails(itemId);

        // Commande pour sauvegarder
        SaveCommand = new Command(OnSave);

        // Commande pour supprimer
        DeleteCommand = new Command(OnDelete);
    }

    private async void LoadShopItemDetails(int itemId)
    {
        var item = await _apiShop.GetShopItemByIdAsync(itemId);
        SelectedItem = item;
    }

    // Méthode de sauvegarde
    private async void OnSave()
    {
        // Logique pour sauvegarder les modifications (si nécessaire)
        await _apiShop.UpdateShopItemAsync(SelectedItem);
    }

    // Méthode de suppression
    private async void OnDelete()
    {
        // Appel de l'API pour supprimer l'élément
        await _apiShop.DeleteShopItemAsync(SelectedItem.IdShop);

        // Redirige vers la page ShopPage
        await Shell.Current.GoToAsync(nameof(ShopPage));
    }
}
