using POS.MultiApp.Events;

namespace POS.MultiApp.LocalStorage;

public interface ILocalStorage
{
    Task<T> GetValueAsync<T>(string key);
    Task SetValueAsync<T>(string key, T value);
    void RemoveValue<T>(string key);
    event EventHandler<ChangedEventArgs> Changed;
}
