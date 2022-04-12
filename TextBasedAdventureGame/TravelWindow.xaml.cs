// TravelWindow
// Programer: Rob Garner (rgarner7@cnm.edu)
// Date: 25 May 2016
// User interface that provides user capability to travel

//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//TravelWindow
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Window that shows player where they are and provides capability to move from location to location in the map.
    /// </summary>
    public partial class TravelWindow : Window
    {
        /// <summary>
        /// Game object that has map
        /// </summary>
        Map game;
        Player P1;
        /// <summary>
        /// Initialize the form, the game and call display location to start the form.
        /// </summary>
        public TravelWindow()
        {
            InitializeComponent();
            game = new Map();
            P1 = new Player(game.Locations[0]);
            DisplayLocation();
        }

        /// <summary>
        /// Tells the player where they are.
        /// </summary>
        private void DisplayLocation()
        {
            txbLocationDescription.Text = P1.Location.Description;
            lbTraveOptions.ItemsSource = P1.Location.TravelOptions;
            lbInventory.ItemsSource = P1.Inventory;
            lbItems.ItemsSource = P1.Location.Items;
        }

        /// <summary>
        /// Double click a travel option to move to a new location on the map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void lbTraveOptions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TravelOption to = (TravelOption)lbTraveOptions.SelectedItem;
            if(to.Location == game.Locations[16] || to.Location == game.Locations[21] || to.Location == game.Locations[23] || to.Location == game.Locations[24] || to.Location == game.Locations[26])
            {
                var w = new YouDied();
                w.txbDescription.Text = to.Location.Description;
                w.ShowDialog();

                if (w.Choice == "Again")
                {
                    game = new Map();
                    P1 = new Player(game.Locations[0]);
                    DisplayLocation();
                }
                else
                {
                    txbLocationDescription.Text = "Thanks for playing, goodbye!";
                    lbInventory.Visibility = Visibility.Collapsed;
                    lbItems.Visibility = Visibility.Collapsed;
                    lbTraveOptions.Visibility = Visibility.Collapsed;
                    txbStatus.Text = "GAME OVER";
                    await Task.Delay(3000);
                    Close();
                }
            }
            else if (to.Location == game.Locations[22])
            {
                lbInventory.Visibility = Visibility.Collapsed;
                lbItems.Visibility = Visibility.Collapsed;
                lbTraveOptions.Visibility = Visibility.Collapsed;
                txbStatus.Text = "Congratulations! You win!";
                System.Threading.Thread.Sleep(5000);
                var w = new YouDied();
                w.grid.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/Sunset.png")));
                w.lblHeader.Content = "YOU WIN";
                w.txbDescription.Text = to.Location.Description;
                w.ShowDialog();

                string Choice = w.Choice;
                if (Choice == "Again")
                {
                    lbInventory.Visibility = Visibility.Visible;
                    lbItems.Visibility = Visibility.Visible;
                    lbTraveOptions.Visibility = Visibility.Visible;
                    txbStatus.Clear();
                    game = new Map();
                    P1 = new Player(game.Locations[0]);
                    DisplayLocation();
                }
                else
                {
                    txbLocationDescription.Text = "Thanks for playing, goodbye!";
                    lbInventory.Visibility = Visibility.Collapsed;
                    lbItems.Visibility = Visibility.Collapsed;
                    lbTraveOptions.Visibility = Visibility.Collapsed;
                    txbStatus.Text = "GAME OVER";
                }
            }
            else
            {
                P1.Location = to.Location;
                DisplayLocation();
            }
        }
        private void lbItems_ItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OnTake(sender, e);
        }
        private void lbInventory_InventoryDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OnDrop(sender, e);
        }
        private void OnSearch(object sender, RoutedEventArgs e)
        {
            if (lbItems.SelectedItem is IHidingPlace)
            {
                IHidingPlace hidingPlace = (IHidingPlace)lbItems.SelectedItem;
                GameObject temp = hidingPlace.Search();
                if (temp != null)
                {
                    P1.Location.Items.Add(temp);
                    txbStatus.Text = $"Congratulations, you found something hidden in {hidingPlace}!\n" +
                        $"The item is now listed with other items.\n" +
                        $"You may now take that item or search it.";
                    lbItems.Items.Refresh();
                }
                else txbStatus.Text = $"[ERROR] {lbItems.SelectedItem} is not portable! Unable to add to your inventory items.";

            }
            else txbStatus.Text = $"{lbItems.SelectedItem} does not seem to be a hiding place.";
        }
        private void OnTake(object sender, RoutedEventArgs e)
        {

            if (lbItems.SelectedItem is IPortable)
            {
                IPortable portable = (IPortable)lbItems.SelectedItem;
                if (P1.AddInventoryItem(portable))
                {
                    P1.Location.Items.Remove(portable as GameObject);
                    lbInventory.Items.Refresh();
                    lbItems.Items.Refresh();
                }
                else txbStatus.Text = $"[ERROR] {portable} requires {portable.Size} inventory slots to take!\n" +
                        $"Unable to add to your inventory items.\n" +
                        $"Please drop some items or expand your maximum inventory size.";

            }
            else txbStatus.Text = "[ERROR] This item is not portable and cannot be added to inventory!";
        }
        private void OnDrop(object sender, RoutedEventArgs e)
        {
            GameObject portable = (GameObject)lbInventory.SelectedItem;
            P1.Inventory.Remove(portable as IPortable);
            P1.Location.Items.Add(portable);
            lbInventory.Items.Refresh();
            lbItems.Items.Refresh();
        }
    }
}
