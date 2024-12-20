namespace SaintMichel.View;

public partial class OffreDetailPage : ContentPage
{
	public OffreDetailPage()
	{
		InitializeComponent();
		BindingContext = new OffreDetailPageViewModel();
    }
}