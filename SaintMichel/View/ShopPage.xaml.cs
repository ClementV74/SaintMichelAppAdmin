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



        
    }
}
