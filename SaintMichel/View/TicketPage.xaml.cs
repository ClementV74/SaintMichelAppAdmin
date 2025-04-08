namespace SaintMichel.View;

public partial class TicketPage : ContentPage
{
    public TicketPage()
    {
        InitializeComponent();
        BindingContext = new TicketPageViewModel();
    }

    private async void OnTicketSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Ticket selectedTicket)
        {
            await Navigation.PushAsync(new TicketDetailPage(selectedTicket));
        }
    }
}