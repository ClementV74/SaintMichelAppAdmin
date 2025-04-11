using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{
    public partial class EventPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Event> _obsItems;

        [ObservableProperty]
        private Event _selectedItem;


        [ObservableProperty]
        private Boolean eventVisibility;

        [ObservableProperty]
        private Boolean eventEnabled;


        public EventPageViewModel()
        {
            Title = "Event Page";
            ObsItems = new ObservableCollection<Event>();
            OnAppearing();
            NavigateToEvents();
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [RelayCommand]
        async Task EventSelected()
        {
            if (SelectedItem == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(EventDetailPage)}?{nameof(EventDetailPageViewModel.IdEvent)}={SelectedItem.IDEvent}");

        }


        [RelayCommand]
        async Task LoadEvent()
        {
            IsBusy = true;
            try
            {
                ObsItems.Clear();

                var List = await EventService.GetAllEventsAsync();

                foreach (var item in List)
                {
                    ObsItems.Add(item);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                IsBusy = false;

            }
        }


        [RelayCommand]
        async Task NavigateToEvents()
        {
            EventVisibility = true;
            EventEnabled = true;
            await LoadEvent();

        }
    }
}
