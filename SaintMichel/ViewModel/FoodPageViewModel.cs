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
        private ObservableCollection<CantineMenuItem> mondayMenus = new();

        [ObservableProperty]
        private ObservableCollection<CantineMenuItem> tuesdayMenus = new();

        [ObservableProperty]
        private ObservableCollection<CantineMenuItem> wednesdayMenus = new();

        [ObservableProperty]
        private ObservableCollection<CantineMenuItem> thursdayMenus = new();

        [ObservableProperty]
        private ObservableCollection<CantineMenuItem> fridayMenus = new();

        [ObservableProperty]
        private string currentWeek;

        private DateTime _currentDate = DateTime.Today;

        public FoodPageViewModel()
        {
            _menuService = new API_Menu();
            UpdateCurrentWeek();
            Task.Run(LoadMenusAsync); // plus safe que async void
        }

        private void UpdateCurrentWeek()
        {
            var startOfWeek = _currentDate.AddDays(-(int)_currentDate.DayOfWeek + (int)DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(4); // Vendredi
            CurrentWeek = $"{startOfWeek:dd MMM} - {endOfWeek:dd MMM}";
        }

        private async Task LoadMenusAsync()
        {
            try
            {
                var startDate = _currentDate.AddDays(-(int)_currentDate.DayOfWeek + (int)DayOfWeek.Monday).ToString("yyyy-MM-dd");
                var endDate = _currentDate.AddDays(-(int)_currentDate.DayOfWeek + (int)DayOfWeek.Friday).ToString("yyyy-MM-dd");

                var menus = await _menuService.GetMenusWeekAsync(startDate, endDate);

                MondayMenus.Clear();
                TuesdayMenus.Clear();
                WednesdayMenus.Clear();
                ThursdayMenus.Clear();
                FridayMenus.Clear();

                foreach (var menu in menus)
                {
                    switch (menu.Jour.ToLower())
                    {
                        case "lundi":
                            MondayMenus.Add(menu);
                            break;
                        case "mardi":
                            TuesdayMenus.Add(menu);
                            break;
                        case "mercredi":
                            WednesdayMenus.Add(menu);
                            break;
                        case "jeudi":
                            ThursdayMenus.Add(menu);
                            break;
                        case "vendredi":
                            FridayMenus.Add(menu);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des menus : {ex.Message}");
            }
        }

        [RelayCommand]
        private async Task PreviousWeekAsync()
        {
            _currentDate = _currentDate.AddDays(-7);
            UpdateCurrentWeek();
            await LoadMenusAsync();
        }

        [RelayCommand]
        private async Task NextWeekAsync()
        {
            _currentDate = _currentDate.AddDays(7);
            UpdateCurrentWeek();
            await LoadMenusAsync();
        }
    }
}
