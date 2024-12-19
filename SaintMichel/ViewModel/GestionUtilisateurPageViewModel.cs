using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{
    public partial class GestionUtilisateurPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<User> _obsItems;

    

        [ObservableProperty]
        private Boolean eventVisibility;


        public GestionUtilisateurPageViewModel()
        {
            Title = "Gestion Utilisateur Page";
            ObsItems = new ObservableCollection<User>();
            LoadUser();
        }


        [RelayCommand]
        async Task LoadUser()
        {
            EventVisibility = true;
            IsBusy = true;
            try
            {
                ObsItems.Clear();

                var List = await UserService.GetAllUsersAsync();

                foreach (var item in List)
                {   
                    ObsItems.Add(item);
                    Console.WriteLine($"User Name: {item.nom}"); // Prints the name of the user

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
            

      
    }
}
