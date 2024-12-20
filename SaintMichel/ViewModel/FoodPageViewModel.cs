using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaintMichel.Model;
using SaintMichel.Services;

namespace SaintMichel.ViewModel
{
    public partial class FoodPageViewModel : ObservableObject
    {
        private readonly API_Menu _menuService;

        [ObservableProperty]
        private ObservableCollection<CantineMenuItem> mondayMenus;
        [ObservableProperty]
        private ObservableCollection<CantineMenuItem> tuesdayMenus;
        [ObservableProperty]
        private ObservableCollection<CantineMenuItem> wednesdayMenus;
        [ObservableProperty]
        private ObservableCollection<CantineMenuItem> thursdayMenus;
        [ObservableProperty]
        private ObservableCollection<CantineMenuItem> fridayMenus;

        [ObservableProperty]
        private string currentWeek;

        private DateTime currentDate;

        public IAsyncRelayCommand PreviousWeekCommand { get; }
        public IAsyncRelayCommand NextWeekCommand { get; }

        public FoodPageViewModel()
        {
            _menuService = new API_Menu();
            mondayMenus = new ObservableCollection<CantineMenuItem>();
            tuesdayMenus = new ObservableCollection<CantineMenuItem>();
            wednesdayMenus = new ObservableCollection<CantineMenuItem>();
            thursdayMenus = new ObservableCollection<CantineMenuItem>();
            fridayMenus = new ObservableCollection<CantineMenuItem>();

            currentDate = DateTime.Today;

            // Initialiser la date actuelle et charger les menus
            UpdateCurrentWeek();
            _ = LoadMenusAsync();

            PreviousWeekCommand = new AsyncRelayCommand(PreviousWeek);
            NextWeekCommand = new AsyncRelayCommand(NextWeek);
        }

        private void UpdateCurrentWeek()
        {
            var startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(4); // Fin de la semaine (vendredi)

            CurrentWeek = $"{startOfWeek:dd MMM} - {endOfWeek:dd MMM yyyy}";
        }

        private async Task LoadMenusAsync()
        {
            try
            {
                var startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday).ToString("yyyy-MM-dd");
                var endDate = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Friday).ToString("yyyy-MM-dd");

                var menus = await _menuService.GetMenusWeekAsync(startDate, endDate);

                mondayMenus.Clear();
                tuesdayMenus.Clear();
                wednesdayMenus.Clear();
                thursdayMenus.Clear();
                fridayMenus.Clear();

                foreach (var menu in menus)
                {
                    switch (menu.Jour.ToLower())
                    {
                        case "lundi":
                            mondayMenus.Add(menu);
                            break;
                        case "mardi":
                            tuesdayMenus.Add(menu);
                            break;
                        case "mercredi":
                            wednesdayMenus.Add(menu);
                            break;
                        case "jeudi":
                            thursdayMenus.Add(menu);
                            break;
                        case "vendredi":
                            fridayMenus.Add(menu);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des menus : {ex.Message}");
            }
        }

        private async Task PreviousWeek()
        {
            currentDate = currentDate.AddDays(-7);
            UpdateCurrentWeek();
            await LoadMenusAsync();
        }

        private async Task NextWeek()
        {
            currentDate = currentDate.AddDays(7);
            UpdateCurrentWeek();
            await LoadMenusAsync();
        }
    }
}
