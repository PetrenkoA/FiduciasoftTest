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
using Catalog.Core;

namespace Catalog.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataService ourTeamsData;

        public MainWindow()
        {
            InitializeComponent();
            ourTeamsData = new DataService();
            lbox_teamsList.ItemsSource = ourTeamsData.Teams;
        }

        private void btn_details_Click(object sender, RoutedEventArgs e)
        {
            if(lbox_teamsList.SelectedItem != null)
            {
                TeamDetails teamDetails = new TeamDetails(ourTeamsData, (Team)lbox_teamsList.SelectedItem);
                teamDetails.Show();
            }
        }
    }
}
