﻿
namespace SaintMichel.ViewModel
{
    public class BaseViewModel : ObservableObject //INotifyPropertyChanged

    {
        protected readonly EventAPI EventService;
        protected readonly OffreAPI OffreService;
        protected readonly UserAPI UserService;
        protected readonly TicketApi TicketApiService;  

        public BaseViewModel()
        {
            EventService = DependencyService.Get<EventAPI>();
            OffreService = DependencyService.Get<OffreAPI>();
            UserService = DependencyService.Get<UserAPI>();
            TicketApiService = DependencyService.Get<TicketApi>();
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        //#region INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //#endregion
    }
}
