using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{

    [QueryProperty(nameof(IdEvent), nameof(IdEvent))]

    public partial class EventDetailPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        private int idEvent;

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

        //public string? IDevent { get; set; }

        public EventDetailPageViewModel()
        {
            Title = "Event Detail";
        }

        [RelayCommand]
        public async Task Confirm()
        {
            Event newEvent = new Event
            {
                IDEvent = idEvent,
                Name = Name,
                Description = Description,
                Date = Date,
                Lieu = Lieu,
                state = int.Parse(State),
                user_iduser = int.Parse(UserIdUser)
            };

            await EventService.UpdateEventAsync(newEvent);

        }

        [RelayCommand]
        public async Task Delete()
        {
            await EventService.DeleteEventAsync(idEvent.ToString());
        }


        partial void OnIdEventChanged(int value)
        {
            if (value > 0) // Si vous souhaitez vérifier que l'ID est valide
            {
                LoadEventDetails(value).ConfigureAwait(false);
            }
            else
            {
                Debug.WriteLine("Invalid EventId provided");
            }
        }

        async Task LoadEventDetails(int OnEventId)
        {
            IsBusy = true;
            try
            {
                int toto = idEvent;
                var _Event = await EventService.GetEventAsync(OnEventId.ToString());

                Name = _Event.Name;
                Description = _Event.Description;
                Date = _Event.Date;
                Lieu = _Event.Lieu;
                State = _Event.state.ToString();
                UserIdUser = _Event.user_iduser.ToString();
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


