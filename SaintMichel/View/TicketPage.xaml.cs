namespace SaintMichel.View;

public partial class TicketPage : ContentPage
{
	public TicketPage()
	{
		InitializeComponent();

        BindingContext = new TicketPageViewModel();
    }
}