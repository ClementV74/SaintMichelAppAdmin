namespace SaintMichel.View;

public partial class SupervisionPage : ContentPage
{
	public SupervisionPage()
	{
		InitializeComponent();

        BindingContext = new SupervisionPageViewModel();

    }
}