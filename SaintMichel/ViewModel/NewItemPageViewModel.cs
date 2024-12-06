

namespace SaintMichel.ViewModel
{
    public partial class NewItemPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        private string? title;

        [ObservableProperty]
        private string? description;


        [RelayCommand]
        async void CancelBtn()
        {
            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");

            await Shell.Current.GoToAsync("///MainPage");

        }

        [RelayCommand]
        async void SaveBtn()
        {
            ToDoList newtodolist = new ToDoList()
            {
                Id = Guid.NewGuid().ToString(),
                Title = Title,
                Description = Description,
                IsDone = false
            };
            await ItemStore.AddItemAsync(newtodolist);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("ItemPage");

        }
    }
}
