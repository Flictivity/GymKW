using GymKW.Data;
using GymKW.Windows;
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

namespace GymKW.Pages
{
    /// <summary>
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            lvClients.ItemsSource = App.Connection.User.Where(x => x.RoleID == 1).ToList();
        }

        private void EditClientBtnClick(object sender, RoutedEventArgs e)
        {
            var window = new ClientWindow((User)lvClients.SelectedItem);
            if (window.ShowDialog() == true)
            {
                lvClients.ItemsSource = App.Connection.User.Where(x => x.RoleID == 1).ToList();
            }
        }

        private void EditClientSubscriptionBtnClick(object sender, RoutedEventArgs e)
        {
            var client = (User)lvClients.SelectedItem;
            var window = new SubscriptionWindow(client);
            if(window.ShowDialog() == true)
            {
                lvClients.ItemsSource = App.Connection.User.Where(x => x.RoleID == 1).ToList();
            }
        }

        private void CreateClientBtnClick(object sender, RoutedEventArgs e)
        {
            var window = new ClientWindow(null);
            if (window.ShowDialog() == true)
            {
                lvClients.ItemsSource = App.Connection.User.Where(x => x.RoleID == 1).ToList();
            }
        }
    }
}
