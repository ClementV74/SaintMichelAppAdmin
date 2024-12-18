namespace SaintMichel.View;

public partial class AddShopPage : ContentPage
{
	public AddShopPage()
	{
		InitializeComponent();
        BindingContext = new AddShopPageViewModel(); // Lier le ViewModel
    }
}