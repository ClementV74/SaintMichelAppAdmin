namespace SaintMichel.View;

public partial class OffresPage : ContentPage
{
	public OffresPage()
	{
		InitializeComponent();
        BindingContext = new OffresPageViewModel();
    }
}