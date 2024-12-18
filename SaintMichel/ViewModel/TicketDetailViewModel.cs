using System.Windows.Input;
namespace SaintMichel.ViewModel;

public class TicketDetailViewModel : BaseViewModel
{
    public Ticket Ticket { get; set; }
    public ICommand ToggleStatusCommand { get; set; }
    public ICommand SendResponseCommand { get; set; }

    public string Title => Ticket.Title;
    public string Description => Ticket.Description;
    public string Status => Ticket.Status;
    public string StatusColor => Ticket.StatusColor;
    public string SubmittedBy => "John Doe"; // Mocked data for now

    private string response;
    public string Response
    {
        get => response;
        set => SetProperty(ref response, value);
    }

    public TicketDetailViewModel(Ticket ticket)
    {
        Ticket = ticket;
        ToggleStatusCommand = new Command(ToggleStatus);
        SendResponseCommand = new Command(SendResponse);
    }

    private void ToggleStatus()
    {
        Ticket.Status = Ticket.Status.ToLower() == "open" ? "Closed" : "Open";
        OnPropertyChanged(nameof(Status));
        OnPropertyChanged(nameof(StatusColor));
    }

    private async void SendResponse()
    {
        // Simulate sending a response
        Console.WriteLine($"Response sent: {Response}");

        // Show confirmation message
        await Application.Current.MainPage.DisplayAlert(
            "Response Sent",
            "Your response has been successfully sent.",
            "OK"
        );

        // Navigate back to the ticket list
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}
