using SaintMichel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{
    public partial class SupervisionPageViewModel : BaseViewModel
    {
        [ObservableProperty] // Private backing field for ObsItems
        private ObservableCollection<ToDoList> _obsItems;

        public SupervisionPageViewModel()
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

        //[RelayCommand]
        //async void ItemTapped(ToDoList item)
        //{
        //    if (item == null)
        //    {

        //        return;

        //    }
        //    await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailPageViewModel.ItemId)}={item.Id}");
        //}

        [RelayCommand]
        async Task NavigateToEvents()
        {

            await Shell.Current.GoToAsync($"{nameof(EventPage)}");

        }

        [RelayCommand]
        async Task NavigateToOffres()
        {

            await Shell.Current.GoToAsync($"{nameof(OffresPage)}");

        }
    }
}
