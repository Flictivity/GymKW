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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            if(App.CurrentUser != null && App.CurrentUser.RoleID == 1)
            {
                btnClients.Visibility = Visibility.Collapsed;
                btnSubs.Visibility = Visibility.Visible;
                btnWorkouts.Visibility = Visibility.Visible;

                MainFrame.Navigate(new SubscriptionPage());
            }
            else if(App.CurrentUser != null && App.CurrentUser.RoleID == 2)
            {
                btnClients.Visibility = Visibility.Visible;
                btnSubs.Visibility = Visibility.Collapsed;
                btnWorkouts.Visibility = Visibility.Collapsed;
                MainFrame.Navigate(new ClientsPage());
            }
        }

        private void SubBtnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SubscriptionPage());
        }

        private void WorkoutBtnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WorkoutPage());
        }

        private void ExitAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
