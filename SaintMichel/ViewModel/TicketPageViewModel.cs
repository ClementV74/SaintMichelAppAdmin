using System.Collections.ObjectModel;
using SaintMichel.Services;

namespace SaintMichel.ViewModel
{
    public partial class TicketPageViewModel : BaseViewModel
    {
        private readonly TicketApi _ticketApi;

        [ObservableProperty]
        private ObservableCollection<Ticket> ticketsitems;

        public TicketPageViewModel()
        {
            _ticketApi = new TicketApi();
            Ticketsitems = new ObservableCollection<Ticket>();
            LoadEventCommand.Execute(null);

            // Abonnez-vous à l'événement envoyé par la page de détail
            MessagingCenter.Subscribe<TicketDetailViewModel, Ticket>(this, "TicketUpdated", (sender, updatedTicket) =>
            {
                // Met à jour le ticket correspondant dans la liste
                var ticket = Ticketsitems.FirstOrDefault(t => t.id_ticket == updatedTicket.id_ticket);
                if (ticket != null)
                {
                    ticket.status = updatedTicket.status;
                    OnPropertyChanged(nameof(Ticketsitems));
                }
            });
        }

        [RelayCommand]
        async Task LoadEvent()
        {
            IsBusy = true;
            try
            {
                Ticketsitems.Clear();
                var list = await _ticketApi.GetAllTicketsAsync();
                foreach (var item in list)
                {
                    Ticketsitems.Add(item);
                }
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
