using Microsoft.Maui.Controls;

namespace SaintMichel.View
{
    public partial class ShopPage : ContentPage
    {
        public ShopPage()
        {
            InitializeComponent();
            BindingContext = new ShopPageViewModel();
        }



        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as ShopItem;

            if (selectedItem != null)
            {
                // Naviguer vers la page de d�tails
                await Shell.Current.GoToAsync($"{nameof(ShopDetailPage)}?itemId={selectedItem.IdShop}");
            }
        }
    }
}
