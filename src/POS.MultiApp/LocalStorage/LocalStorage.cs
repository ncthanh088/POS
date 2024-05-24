
using System.Text.Json;
using POS.MultiApp.Events;

namespace POS.MultiApp.LocalStorage;

public class LocalStorage : ILocalStorage
{
    public event EventHandler<ChangedEventArgs> Changed;

    public async Task SetValueAsync<T>(string key, T value)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        var json = JsonSerializer.Serialize(value);
        await SecureStorage.Default.SetAsync(key, json);

        OnChanged(new ChangedEventArgs(key));
    }

    public async Task<T> GetValueAsync<T>(string key)
    {
        var value = await SecureStorage.Default.GetAsync(key);
        if (value != null)
        {
            return JsonSerializer.Deserialize<T>(value);
        }
        return default(T);
    }

    public void RemoveValue<T>(string key) => SecureStorage.Default.Remove(key);

    protected virtual void OnChanged(ChangedEventArgs e)
    {
        Changed?.Invoke(this, e);
    }

    public void RemoveAll()
    {
        SecureStorage.Default.RemoveAll();
    }
}
