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
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [RelayCommand]
        async Task LoadItems()
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

        [RelayCommand]
        async void ItemTapped(Ticket ticket)
        {
            if (ticket == null)
            {

                return;
            }
            //await Shell.Current.GoToAsync($"{nameof(TicketDetailPage)}?{nameof(TicketDetailViewModel.TicketId)}={ticket.id_ticket}");
            //await Shell.Current.GoToAsync($"{nameof(ShopPage)}");
        }

    }
}