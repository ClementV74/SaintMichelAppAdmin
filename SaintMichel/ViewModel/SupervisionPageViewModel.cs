using Microsoft.Maui.Controls.Handlers.Items;
using SaintMichel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaintMichel.Services;
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
        

        public SupervisionPageViewModel()
        {
            Title = "Supervision Page";
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

                var List = await API_Offres.GetItemsAsync(true);

                foreach (var item in List)
                {
                    ObsItems2.Add(item);
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
        async Task LoadEvent()
        {
            IsBusy = true;
            try
            {
                ObsItems.Clear();

                var List = await API_Event.GetItemsAsync();

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
