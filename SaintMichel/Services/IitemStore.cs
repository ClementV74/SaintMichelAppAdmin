
namespace SaintMichel.Services
{
    public interface IitemStore<T>
    {
        Task<bool> AddItemAsync(T contact);
        Task<bool> UpdateItemAsync(T contact);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

    }
}
