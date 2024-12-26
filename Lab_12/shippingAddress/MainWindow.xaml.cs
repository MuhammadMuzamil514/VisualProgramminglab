using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace WpfApp11
{
    public partial class MainWindow : Window
    {
        // ObservableCollection to hold addresses in memory
        public ObservableCollection<Address> Addresses { get; set; } = new ObservableCollection<Address>();

        public MainWindow()
        {
            InitializeComponent();
            LoadDefaultAddresses();
            AddressComboBox.ItemsSource = Addresses; // Binding the addresses to the ComboBox
        }

        // Method to load some default addresses (simulating database entries)
        private void LoadDefaultAddresses()
        {
            // Adding a few sample addresses
            Addresses.Add(new Address { AddressLine1 = "123 Elm St", City = "Springfield", State = "IL", ZipCode = "62704" });
            Addresses.Add(new Address { AddressLine1 = "456 Oak St", City = "Shelbyville", State = "IL", ZipCode = "62563" });
        }

        // Event when an address is selected from the ComboBox
        private void AddressComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (AddressComboBox.SelectedItem is Address selectedAddress)
            {
                ShippingAddressTextBox.Text = selectedAddress.ToString(); // Display selected address in the TextBox
            }
        }

        // Event to add a new address to the list
        private void AddNewAddress_Click(object sender, RoutedEventArgs e)
        {
            // Make the TextBox visible for the user to enter a new address
            ShippingAddressTextBox.Visibility = Visibility.Visible;

            // Clear any existing text in the TextBox
            ShippingAddressTextBox.Clear();

            // Optionally, you can focus on the TextBox so the user can start typing immediately
            ShippingAddressTextBox.Focus();
        }

        // Event to save the changes made to the shipping address
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var newAddressText = ShippingAddressTextBox.Text;

            // Validate the address input (ensure it's not empty)
            if (string.IsNullOrWhiteSpace(newAddressText))
            {
                MessageBox.Show("Please enter a valid address.");
                return;
            }

            // Split the entered address into components (you could implement better validation here)
            var addressParts = newAddressText.Split(',');

            if (addressParts.Length != 4)
            {
                MessageBox.Show("Please enter the address in the correct format: AddressLine1, City, State, ZipCode");
                return;
            }

            // Add the new address to the list
            Addresses.Add(new Address
            {
                AddressLine1 = addressParts[0].Trim(),
                City = addressParts[1].Trim(),
                State = addressParts[2].Trim(),
                ZipCode = addressParts[3].Trim()
            });

            // Show a confirmation message
            MessageBox.Show("New address added to the list!");

            // Optionally, clear the TextBox after adding the address
            ShippingAddressTextBox.Clear();

            // Hide the TextBox again after adding the address
            ShippingAddressTextBox.Visibility = Visibility.Collapsed;
        }
    }

    // Simple Address class representing an address
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public override string ToString() => $"{AddressLine1}, {City}, {State}, {ZipCode}";
    }
}
