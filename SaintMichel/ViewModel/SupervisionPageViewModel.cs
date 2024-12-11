using Microsoft.Maui.Controls.Handlers.Items;
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
        [ObservableProperty] 
        private ObservableCollection<Event> _obsItems;

        [ObservableProperty] 
        private ObservableCollection<Offre> _obsItems2;

        [ObservableProperty]
        private Boolean eventVisibility;

        [ObservableProperty]
        private Boolean offreVisibility;
        

        DAO_SaintMichelAPI dao_SaintMichelAPI;

        public SupervisionPageViewModel()
        {
            Title = "Supervision Page";
            dao_SaintMichelAPI = new DAO_SaintMichelAPI();
            ObsItems = new ObservableCollection<Event>();
            ObsItems2 = new ObservableCollection<Offre>();
            OnAppearing();
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [RelayCommand]
        async Task LoadOffres()
        {
            IsBusy = true;
            try
            {
                ObsItems2.Clear();
                var List = await dao_SaintMichelAPI.GetOffresAsync();

                foreach (var item in List)
                {
                    ObsItems2.Add(item);
                }

                await App.Current.MainPage.DisplayAlert("Alert", $"{ObsItems2.Count} offres found", "OK");
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
        async Task LoadEvent()
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

        [RelayCommand]
        async Task NavigateToEvents()
        {
            EventVisibility = true;
            OffreVisibility = false;
            await LoadEvent();

        }

        [RelayCommand]
        async Task NavigateToOffres()
        {
            OffreVisibility = true;
            EventVisibility = false;
            await LoadOffres();

        }
    }
}
