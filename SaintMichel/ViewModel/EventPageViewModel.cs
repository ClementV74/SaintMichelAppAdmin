using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaintMichel.Services;
using SaintMichel.Model;

namespace SaintMichel.ViewModel
{
    public partial class EventPageViewModel : BaseViewModel
    {
        [ObservableProperty] // Private backing field for ObsItems
        private ObservableCollection<Event> _obsItems;

        DAO_SaintMichelAPI dao_SaintMichelAPI;

        public EventPageViewModel()
        {
            Title = "Event Page";
            ObsItems = new ObservableCollection<Event>();
            dao_SaintMichelAPI = new DAO_SaintMichelAPI();
            OnAppearing();
        }

        public async void OnAppearing()
        {
            IsBusy = true;
            await LoadItems();
        }

        [RelayCommand]
        async Task LoadItems()
        {
            IsBusy = true;
            try
            {
                ObsItems.Clear();
                var List = await dao_SaintMichelAPI.GetEventsAsync();

                foreach (var item in List)
                {
                    ObsItems.Add(item);
                }

                 await App.Current.MainPage.DisplayAlert("Alert", $"{ObsItems.Count} items found", "OK");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                IsBusy = false;

            }
        }
    }
}
