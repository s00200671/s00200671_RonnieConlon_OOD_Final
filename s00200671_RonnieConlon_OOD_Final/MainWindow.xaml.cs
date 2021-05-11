using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace s00200671_RonnieConlon_OOD_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Game> Games;
        List<Game> FilteredGames;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the db
            GameInformation db = new GameInformation();

            // Query for games
            var query = from g in db.Games
                        select g;

            // Get the list of queried games
            Games = query.ToList();

            // Set lbx source to the games list
            lbxGames.ItemsSource = Games;

            // Init the Filtered games list
            FilteredGames = new List<Game>();
            // Make the inital cbx for platform searching the "all" selection
            Platform_cbx.SelectedIndex = 0;
        }

        private void lbxGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Game selectedGame = lbxGames.SelectedItem as Game;

            if (selectedGame != null)
            {
                Game_IMG.Source = new BitmapImage(new Uri(selectedGame.GameImage, UriKind.Relative));
                GamePrice_tblk.Text = $"{selectedGame.Price:C}";
                GamePlatform_tblk.Text = selectedGame.Platform;
                GameDesc_tblk.Text = selectedGame.Description;
            }
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            // Get the selected choice
            string choice = Platform_cbx.Text.ToLower();
            
            // Set list to null to refresh
            lbxGames.ItemsSource = null;

            // If the choice is all, just set the source to all games list
            if (choice == "all")
            {
                lbxGames.ItemsSource = Games;
            }
            else
            {
                // Clear the filtered list
                FilteredGames.Clear();

                // For each game, check is the platform string contains the choice, if so, add it to the filtered list
                foreach(Game game in Games)
                {
                    if (game.Platform.ToLower().Contains(choice))
                    {
                        FilteredGames.Add(game);
                    }
                }

                lbxGames.ItemsSource = FilteredGames;
            }
        }
    }
}
