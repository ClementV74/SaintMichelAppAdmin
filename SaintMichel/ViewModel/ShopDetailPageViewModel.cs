using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

public partial class ShopDetailPageViewModel : ObservableObject
{
    private readonly API_Shop _apiShop = new API_Shop();

    [ObservableProperty]
    private ShopItem selectedItem;

    public ShopDetailPageViewModel(int itemId)
    {
        LoadShopItemDetailsAsync(itemId);
    }

    private async void LoadShopItemDetailsAsync(int itemId)
    {
        var item = await _apiShop.GetShopItemByIdAsync(itemId);
        SelectedItem = item;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (SelectedItem == null)
            return;

        await _apiShop.UpdateShopItemAsync(SelectedItem);

        await Shell.Current.DisplayAlert("Succès", "Article sauvegardé avec succès !", "OK");
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (SelectedItem == null)
            return;

        bool confirm = await Shell.Current.DisplayAlert(
            "Confirmation",
            "Es-tu sûr de vouloir supprimer cet article ?",
            "Oui", "Non");

        if (!confirm)
            return;

        await _apiShop.DeleteShopItemAsync(SelectedItem.IdShop);

        await Shell.Current.DisplayAlert("Succès", "Article supprimé.", "OK");

        // Retour à la page précédente
        await Shell.Current.GoToAsync("..");
    }
}
