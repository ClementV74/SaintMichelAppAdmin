using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using SaintMichel.Services;
using SaintMichel.Model;

namespace SaintMichel.ViewModel
{
    public class FoodPageViewModel : BaseViewModel
    {
        private readonly API_Menu _menuService;

        public ObservableCollection<CantineMenuItem> Menus { get; set; }
        public ICommand LoadMenusCommand { get; }

        public FoodPageViewModel()
        {
            _menuService = new API_Menu();
            Menus = new ObservableCollection<CantineMenuItem>();
            LoadMenusCommand = new Command(async () => await LoadMenus());
        }

        // Charger les menus pour une semaine
        private async Task LoadMenus()
        {
            try
            {
                var menus = await _menuService.GetMenusForWeekAsync("2024-12-01", "2024-12-07");
                Menus.Clear();
                foreach (var menu in menus)
                {
                    Menus.Add(menu);
                }
            }
            catch (Exception ex)
            {
                // Gérez l'erreur ici (par exemple, afficher un message à l'utilisateur)
                Console.WriteLine(ex.Message);
            }
        }
    }
}
