using System.Collections.ObjectModel;
namespace SaintMichel.ViewModel;

public class TicketPageViewModel : BaseViewModel
{
    public ObservableCollection<Ticket> Tickets { get; set; }

    public TicketPageViewModel()
    {
        Tickets = new ObservableCollection<Ticket>(MockTicketService.GetMockTickets());
    }
}
