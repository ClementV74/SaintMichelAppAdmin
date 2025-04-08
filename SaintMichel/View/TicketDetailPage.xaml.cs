namespace SaintMichel.View;

public partial class TicketDetailPage : ContentPage
{
    public TicketDetailPage(Ticket ticket)
    {
        InitializeComponent();
        BindingContext = new TicketDetailViewModel(ticket);
    }
}