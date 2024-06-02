using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GymKW.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AuthorizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existUser = App.Connection.User.FirstOrDefault(x => x.Mail ==  Email.Text);
            if (existUser == null) 
            {
                MessageBox.Show("Пользователь не сущетсвует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(existUser.Passwword != Password.Password) 
            {
                MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            App.CurrentUser = existUser;
            NavigationService.Navigate(new MainPage());
        }
    }
}