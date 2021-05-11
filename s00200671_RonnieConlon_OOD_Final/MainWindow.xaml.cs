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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameInformation db = new GameInformation();

            var query = from g in db.Games
                        select g;

            Games = query.ToList();

            lbxGames.ItemsSource = Games;
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
    }
}
