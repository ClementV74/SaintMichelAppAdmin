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
        async Task LoadItems()
        {
            //IsBusy = true;
            //try
            //{
            //    ObsItems.Clear();
            //    var items = await ItemStore.GetItemsAsync(true);

            //    foreach (var item in items)
            //    {
            //        ObsItems.Add(item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
            //finally
            //{
            //    IsBusy = false;

            //}
        }

        [RelayCommand]
        async void ItemTapped(ToDoList item)
        {
            if (item == null)
            {

                return;
                
            }
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailPageViewModel.ItemId)}={item.Id}");
        }

        [RelayCommand]
        async Task AddItem()
        {
           
            await Shell.Current.GoToAsync($"{nameof(NewItemPage)}");
         
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
        async Task NavigateToSupervision()
        {
            await Shell.Current.GoToAsync(nameof(SupervisionPage));
        }

        [RelayCommand]
        async Task NavigateToGestionUtilisateur()
        {
            await Shell.Current.GoToAsync(nameof(GestionUtilisateurPage));
        }


    }
}
