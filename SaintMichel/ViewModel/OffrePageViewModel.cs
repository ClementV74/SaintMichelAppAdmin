using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{
    public partial class OffrePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<OffrePro> _obsItems2;

        [ObservableProperty]
        private OffrePro _selectedOffre;

        [ObservableProperty]
        private Boolean offreVisibility;

        [ObservableProperty]
        private Boolean offreEnabled;



        public OffrePageViewModel()
        {
            Title = "Offre Page";
            ObsItems2 = new ObservableCollection<OffrePro>();
            OnAppearing();
        }

        public void OnAppearing()
        {
            IsBusy = true;
            NavigateToOffres();

        }
        [RelayCommand]
        async Task OffreSelected()
        {
            if (SelectedOffre == null)
            {
                return;
            }


            await Shell.Current.GoToAsync($"{nameof(OffreDetailPage)}?{nameof(OffreDetailPageViewModel.IDInterim)}={SelectedOffre.IDInterim}");
        }

        [RelayCommand]
        async Task LoadOffres()
        {
            IsBusy = true;
            try
            {
                ObsItems2.Clear();

                var List = await OffreService.GetAllOffresAsync();

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
        async Task NavigateToOffres()
        {
            OffreVisibility = true;
            OffreEnabled = true;
            await LoadOffres();

        }
    }
}
