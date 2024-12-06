namespace SaintMichel.View;

public partial class GestionUtilisateurPage : ContentPage
{
	public GestionUtilisateurPage()
	{
		InitializeComponent();

        BindingContext = new GestionUtilisateurPageViewModel();

    }
}