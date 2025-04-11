namespace SaintMichel.View;

public partial class OffrePage : ContentPage
{
	public OffrePage()
	{
		InitializeComponent();

		BindingContext = new OffrePageViewModel();
    }
}