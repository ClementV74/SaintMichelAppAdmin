namespace SaintMichel.View;

public partial class FoodPage : ContentPage
{
	public FoodPage()
	{
		InitializeComponent();

        BindingContext = new FoodPageViewModel();

    }
}