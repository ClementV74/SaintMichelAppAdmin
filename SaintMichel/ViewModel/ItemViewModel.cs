namespace SaintMichel.ViewModel
{
    public partial class ItemViewModel : BaseViewModel
    {
        [ObservableProperty] // Private backing field for ObsItems
        private ObservableCollection<ToDoList> _obsItems;

        public ItemViewModel()
        {
            Title = "To DO List";
            //ObsItems = new ObservableCollection<ToDoList>();
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [RelayCommand]
        async Task NavigateToFood()
        {
            await Shell.Current.GoToAsync(nameof(FoodPage));
        }

        [RelayCommand]
        async Task NavigateToTicket()
        {
            await Shell.Current.GoToAsync(nameof(TicketPage));
        }

        [RelayCommand]
        async Task NavigateToShop()
        {
            await Shell.Current.GoToAsync(nameof(ShopPage));
        }

        [RelayCommand]
        async Task NavigateToEvenements()
        {
            await Shell.Current.GoToAsync(nameof(EventPage));
        }

        [RelayCommand]
        async Task NavigateToOffres()
        {
            await Shell.Current.GoToAsync(nameof(OffrePage));
        }

        [RelayCommand]
        async Task NavigateToGestionUtilisateur()
        {
            await Shell.Current.GoToAsync(nameof(GestionUtilisateurPage));
        }


    }
}
