using POS.MultiApp.Models;
using System.ComponentModel;

namespace POS.MultiApp;

public class AppState : INotifyPropertyChanged
{
    private CartItem _selectedItem;
    private Receipt _receipt;

    public CartItem SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (_selectedItem != value)
            {
                _selectedItem = value;
                NotifyPropertyChanged(nameof(SelectedItem));
            }
        }
    }

    public Receipt Receipt
    {
        get => _receipt;
        set
        {
            if (_receipt != value)
            {
                _receipt = value;
                NotifyPropertyChanged(nameof(Receipt));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
