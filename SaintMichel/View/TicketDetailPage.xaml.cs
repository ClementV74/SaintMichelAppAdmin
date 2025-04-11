namespace SaintMichel.View;

public partial class TicketDetailPage : ContentPage
{
    public TicketDetailPage()
    {
        InitializeComponent();
        BindingContext = new TicketDetailViewModel();
    }
}