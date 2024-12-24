using System.Collections.ObjectModel;
using System.ComponentModel;

public class OrderInfo : INotifyPropertyChanged
{
    private string _shippingAddress;
    public string ShippingAddress
    {
        get { return _shippingAddress; }
        set
        {
            if (_shippingAddress != value)
            {
                _shippingAddress = value;
                OnPropertyChanged(nameof(ShippingAddress));
            }
        }
    }

    public ObservableCollection<string> Addresses { get; set; }

    public OrderInfo()
    {
        Addresses = new ObservableCollection<string>
        {
            "Address 1",
            "Address 2",
            "Address 3"
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
