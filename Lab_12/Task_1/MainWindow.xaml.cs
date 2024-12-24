using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Lab_12_Task_1
{
    public partial class MainWindow : Window
    {
        private List<string> addresses;

        // Dependency Property for ShippingAddress  
        public static readonly DependencyProperty ShippingAddressProperty =
            DependencyProperty.Register("ShippingAddress", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));

        public string ShippingAddress
        {
            get { return (string)GetValue(ShippingAddressProperty); }
            set { SetValue(ShippingAddressProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadAddresses();
            DataContext = this; // Set DataContext for data binding  
        }

        private void LoadAddresses()
        {
            // Sample addresses  
            addresses = new List<string>
            {
                "123 Main St, City, Country",
                "456 Elm St, City, Country"
            };
            AddressComboBox.ItemsSource = addresses;
        }

        private void ChangeAddress_Click(object sender, RoutedEventArgs e)
        {
            if (AddressComboBox.SelectedItem != null)
            {
                ShippingAddress = AddressComboBox.SelectedItem.ToString();
                MessageBox.Show("Shipping address changed to: " + ShippingAddress);
            }
            else
            {
                MessageBox.Show("Please select an existing address.");
            }
        }

        private void AddAddress_Click(object sender, RoutedEventArgs e)
        {
            string newAddress = NewAddressTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newAddress))
            {
                addresses.Add(newAddress);
                AddressComboBox.ItemsSource = null; // Reset the ComboBox data source  
                AddressComboBox.ItemsSource = addresses; // Reassign the updated address list  
                NewAddressTextBox.Clear(); // Clear the TextBox  
                MessageBox.Show("New address added.");
            }
            else
            {
                MessageBox.Show("Please enter a valid address.");
            }
        }

        public void AddressComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Update shipping address when the selection changes  
            if (AddressComboBox.SelectedItem != null)
            {
                ShippingAddress = AddressComboBox.SelectedItem.ToString();
            }
        }
    }

}
