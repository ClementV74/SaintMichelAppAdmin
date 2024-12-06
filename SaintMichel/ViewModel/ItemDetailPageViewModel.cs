
namespace SaintMichel.ViewModel
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class ItemDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? itemId;
        [ObservableProperty]
        private string? title;
        [ObservableProperty]
        private string? description;
        public string Id { get; set; }


        partial void OnItemIdChanged(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                LoadItemId(value).ConfigureAwait(false);
            }
            else
            {
                Debug.WriteLine("Invalid ItemId provided");
            }
        }

        private async Task LoadItemId(string itemId)
        {
            try
            {
                var item = await ItemStore.GetItemAsync(itemId);
                Id = item.Id;
                Title = item.Title;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load item");
            }
        }
    }
}
