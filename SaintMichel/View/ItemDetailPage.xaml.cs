namespace SaintMichel.View;

public partial class ItemDetailPage : ContentPage
{
	public ItemDetailPage()
	{
		InitializeComponent();

        BindingContext = new ItemDetailPageViewModel();
    }
}