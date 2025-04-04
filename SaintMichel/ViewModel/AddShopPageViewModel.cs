using Microsoft.Maui.Controls;
using System.Windows.Input;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{
    public class AddShopPageViewModel : BindableObject
    {
        private string _title;
        private decimal _prix;
        private string _imageUrl;
        private string _description;
        private readonly API_Shop _apiShop;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public decimal Prix
        {
            get => _prix;
            set
            {
                _prix = value;
                OnPropertyChanged();
            }
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddShopCommand { get; }

        public AddShopPageViewModel()
        {
            _apiShop = new API_Shop();
            AddShopCommand = new Command(async () => await AddShopItem());
        }

        private async Task AddShopItem()
        {
            // Validation des champs
            if (string.IsNullOrEmpty(Title) || Prix <= 0 || string.IsNullOrEmpty(ImageUrl) || string.IsNullOrEmpty(Description))
            {
                // Afficher un message d'erreur si un champ est vide
                await Shell.Current.DisplayAlert("Erreur", "Tous les champs doivent être remplis", "OK");
                return;
            }

            // Créer un nouvel objet ShopItem
            var newShopItem = new ShopItem
            {
                Title = Title,
                Prix = (double)Prix,
                ImageUrl = ImageUrl,
                Description = Description
            };

            try
            {
                // Appeler l'API pour ajouter l'élément
                await _apiShop.AddShopItemAsync(newShopItem);
                // Afficher un message de confirmation
                await Shell.Current.DisplayAlert("Succès", "L'article a été ajouté", "OK");

                // Réinitialiser les champs après l'ajout
                Title = string.Empty;
                Prix = 0;
                ImageUrl = string.Empty;
                Description = string.Empty;

                // Naviguer vers la page principale (ShopPage)
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur en cas de problème
                await Shell.Current.DisplayAlert("Erreur", ex.Message, "OK");
            }
        }
    }
}
