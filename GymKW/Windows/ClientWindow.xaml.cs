using GymKW.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace GymKW.Windows
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private bool _isEdit;
        private User _user = new User();
        public ClientWindow(User user)
        {
            InitializeComponent();
            _user.BirthDate = DateTime.Today.AddDays(-1);
            if(user != null)
            {
                _user = user;
                _isEdit = true;
                Password.Password = _user.Passwword;
            }

            DataContext = _user;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _user.Passwword = Password.Password;
                if (string.IsNullOrEmpty(_user.Surname) ||
                    string.IsNullOrEmpty(_user.Name) ||
                    string.IsNullOrEmpty(_user.Patronymic) ||
                    string.IsNullOrEmpty(_user.Mail) ||
                    string.IsNullOrEmpty(_user.PhoneNumber) ||
                    string.IsNullOrEmpty(_user.Passwword) ||
                    _user.BirthDate == null)
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (_user.BirthDate >= DateTime.Now)
                {
                    MessageBox.Show("Неверная дата рождения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _user.RoleID = 1;
                App.Connection.User.AddOrUpdate(_user);
                App.Connection.SaveChanges();
                DialogResult = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
