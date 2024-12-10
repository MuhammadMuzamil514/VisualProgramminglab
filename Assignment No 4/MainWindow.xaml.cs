using System.Collections.ObjectModel;
using System.Windows;

namespace CricketTeamManager
{
    public partial class MainWindow : Window
    {
        // ObservableCollection to manage player list
        public ObservableCollection<string> Players { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the ObservableCollection and bind it to the ListBox
            Players = new ObservableCollection<string>();
            PlayerListBox.ItemsSource = Players;
        }

        // Event handler for adding a player
        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the player name from the TextBox
            string playerName = PlayerNameTextBox.Text.Trim();

            // Validation: Prevent empty or duplicate names
            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Player name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Players.Contains(playerName))
            {
                MessageBox.Show("Player name already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add the player to the collection
            Players.Add(playerName);

            // Clear the TextBox and display a success message
            PlayerNameTextBox.Clear();
            MessageBox.Show("Player added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for removing a player
        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a player is selected in the ListBox
            if (PlayerListBox.SelectedItem is string selectedPlayer)
            {
                // Remove the selected player from the collection
                Players.Remove(selectedPlayer);
                MessageBox.Show("Player removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // If no player is selected, show a warning
                MessageBox.Show("Please select a player to remove.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
