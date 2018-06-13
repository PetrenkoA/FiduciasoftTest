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
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    /// 

    public partial class TeamDetails : Window
    {
        DataService DataProvider;
        Team thisTem;

        public TeamDetails(DataService Dataprovider, Team team)
        {
            InitializeComponent();
            thisTem = team;
            tbx_name.Text = team.Name;
            tbx_country.Text = team.Country;
            tbx_year.Text = team.FoundationYear;
            DataProvider = Dataprovider;

            UpdateListBox();
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            PlayerAddWindow win = new PlayerAddWindow(DataProvider);
            if(win.ShowDialog().Value == true && win.SelectedPerson != null)
            {
                Person newMember = DataProvider.People.FirstOrDefault(x => x.Name == win.SelectedPerson.Name);
                newMember.Team = thisTem;
                UpdateListBox();
            }
        }

        public void UpdateListBox()
        {
            var list = DataProvider.People.Where(x => x.Team != null && x.Team.Name == thisTem.Name);
            lbox_playersList.ItemsSource = list;
        }
    }
}
