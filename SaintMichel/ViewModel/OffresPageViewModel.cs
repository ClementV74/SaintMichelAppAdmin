using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{
    public partial class OffresPageViewModel : BaseViewModel
    {
        [ObservableProperty] // Private backing field for ObsItems
        private ObservableCollection<OffrePro> _obsItems;

        //DAO_SaintMichelAPI dao_SaintMichelAPI;

        //public OffresPageViewModel()
        //{
        //    Title = "Offres Page";
        //    ObsItems = new ObservableCollection<Offre>();
        //    dao_SaintMichelAPI = new DAO_SaintMichelAPI();
        //    OnAppearing();
        //}

        //public async void OnAppearing()
        //{
        //    IsBusy = true;
        //    await LoadItems();
        //}

        //[RelayCommand]
        //async Task LoadItems()
        //{
        //    IsBusy = true;
        //    try
        //    {
        //        ObsItems.Clear();
        //        var List = await dao_SaintMichelAPI.GetOffresAsync();

        //        foreach (var item in List)
        //        {
        //            ObsItems.Add(item);
        //        }

        //        await App.Current.MainPage.DisplayAlert("Alert", $"{ObsItems.Count} offres found", "OK");
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    finally
        //    {
        //        IsBusy = false;

        //    }
        //}
    }
}
