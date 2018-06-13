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
using Catalog.Core;

namespace Catalog.UI
{
    /// <summary>
    /// Interaction logic for PlayerAddWindow.xaml
    /// </summary>
    public partial class PlayerAddWindow : Window
    {
        public Person SelectedPerson;
        public PlayerAddWindow( DataService DataProvider)
        {
            InitializeComponent();
            lbox_playersList.ItemsSource = DataProvider.People.Where(x => x.Team == null);
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            SelectedPerson = (Person)lbox_playersList.SelectedItem;
            this.DialogResult = true;
        }
    }
}
