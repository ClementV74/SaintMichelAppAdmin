using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{
    [QueryProperty(nameof(IDInterim), nameof(IDInterim))]
    public partial class OffreDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private int idInterim;

        [ObservableProperty]
        private string dateStart;

        [ObservableProperty]
        private string dateEnd;

        [ObservableProperty]
        private string nameEntreprise;

        [ObservableProperty]
        private string nameVille;

        [ObservableProperty]
        private string tache;

        [ObservableProperty]
        private string type_offre;

        [ObservableProperty]
        private string secteurActivite;

        public int IDInterim { get; set; } 

        public OffreDetailPageViewModel()
        {
            Title = "Offre Detail";
        }

        [RelayCommand]
        public async Task Confirm()
        {
            var newOffre = new OffrePro
            {
                IDInterim = IDInterim,
                DateStart = DateStart,
                DateEnd = DateEnd,
                NameEntreprise = NameEntreprise,
                NameVille = NameVille,
                Tache = Tache,
                type_offre = type_offre,
                SecteurActivite = SecteurActivite
            };

            await OffreService.UpdateOffreAsync(newOffre);
        }

        [RelayCommand]
        public async Task Delete()
        {
            await OffreService.DeleteOffreAsync(IDInterim.ToString());
        }

        private async Task LoadOffreDetails(int idInterim)
        {
            IsBusy = true;
            try
            {
                var offre = await OffreService.GetOffreAsync(idInterim.ToString());

                DateStart = offre.DateStart;
                DateEnd = offre.DateEnd;
                NameEntreprise = offre.NameEntreprise;
                NameVille = offre.NameVille;
                Tache = offre.Tache;
                type_offre = offre.type_offre;
                SecteurActivite = offre.SecteurActivite;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading offre details: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
