namespace SaintMichel.View;

public partial class NewItemPage : ContentPage
{
	public NewItemPage()
	{
		InitializeComponent();

        BindingContext = new NewItemPageViewModel();
    }
}