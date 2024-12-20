using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{
    public partial class EventDetailPageViewModel : BaseViewModel
    {
        public int EventId;

        [ObservableProperty]
        private string _Name;

        [ObservableProperty]
        private string _Description;

        [ObservableProperty]
        private string _Date;

        [ObservableProperty]
        private string _Lieu;

        [ObservableProperty]
        private string _State;

        [ObservableProperty]
        private string _UserIdUser;

 
        public EventDetailPageViewModel()
        {
            Title = "Event Detail";
            OnAppearing();
        }

        public async void OnAppearing()
        {
            IsBusy = true;
            await LoadEventDetails();
        }

        async Task LoadEventDetails()
        {
            IsBusy = true;
            try
            {

                var _Event = await EventService.GetEventAsync(EventId.ToString());
                Name = _Event.Name;
                Description = _Event.Description;
                Date = _Event.Date;
                Lieu = _Event.Lieu;
                State = _Event.state.ToString();
                UserIdUser = _Event.user_iduser.ToString();

                await Application.Current.MainPage.DisplayAlert("Warning", $"The event location {Lieu} is not set.", "OK");
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


