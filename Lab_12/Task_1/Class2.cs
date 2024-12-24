using System.Windows;

public class AddressProperties : DependencyObject
{
    public static readonly DependencyProperty ShippingAddressProperty =
        DependencyProperty.RegisterAttached("ShippingAddress", typeof(string), typeof(AddressProperties), new PropertyMetadata(null));

    public static string GetShippingAddress(DependencyObject obj)
    {
        return (string)obj.GetValue(ShippingAddressProperty);
    }

    public static void SetShippingAddress(DependencyObject obj, string value)
    {
        obj.SetValue(ShippingAddressProperty, value);
    }
}
