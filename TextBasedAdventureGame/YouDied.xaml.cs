//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//YouDied

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
using System.Windows.Shapes;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Interaction logic for YouDied.xaml
    /// </summary>
    public partial class YouDied : Window
    {
        public string Choice { get; set; }
        public YouDied()
        {
            InitializeComponent();
        }
        private void OnAgainClick(object sender, RoutedEventArgs e) { Choice = "Again"; Close(); }
        private void OnQuitClick(object sender, RoutedEventArgs e) { Choice = "Quit"; Close(); }
    }
}
