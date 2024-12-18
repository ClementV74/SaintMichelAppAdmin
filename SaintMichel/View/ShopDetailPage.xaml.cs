using Microsoft.Maui.Controls;

namespace SaintMichel.View
{
    [QueryProperty(nameof(ItemId), "itemId")]
    public partial class ShopDetailPage : ContentPage
    {
        public int ItemId { get; set; }

        public ShopDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Initialiser le ViewModel avec l'ID
            BindingContext = new ShopDetailPageViewModel(ItemId);
        }
    }
}
