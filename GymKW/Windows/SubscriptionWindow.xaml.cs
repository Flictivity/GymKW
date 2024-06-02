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
    /// Interaction logic for SubscriptionWindow.xaml
    /// </summary>
    public partial class SubscriptionWindow : Window
    {
        private User _user;
        private Subscription _userSubscription;
        private List<SubscriptionType> _subscriptionTypes;
        public SubscriptionWindow(User user)
        {
            InitializeComponent();
            _user = user;
            DataContext = _user;
            _userSubscription = App.Connection.Subscription.OrderByDescending(x => x.Id).FirstOrDefault(x => x.UserID == _user.Id);

            if(_userSubscription != null )
            {
                dpStartDate.SelectedDate = _userSubscription.StartDate;
                dpEndDate.SelectedDate = _userSubscription.EndDate;
                tbPrice.Text = _userSubscription.Price.ToString();
            }
            LoadSubscriptionTypes();
        }

        private void LoadSubscriptionTypes()
        {
            _subscriptionTypes = App.Connection.SubscriptionType.ToList();
            foreach (var subscriptionType in _subscriptionTypes)
            {
                subscriptionType.IsChecked = _userSubscription.SubscriptionTypeID == subscriptionType.Id;
            }
            lbSubscriptionTypes.ItemsSource = _subscriptionTypes;
        }

        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_subscriptionTypes.Where(x=> x.IsChecked).Count() > 1) {
                    MessageBox.Show("Не возможно установить более одного типа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrEmpty(tbPrice.Text) || dpStartDate.SelectedDate == DateTime.MinValue
               || dpEndDate.SelectedDate == DateTime.MinValue
               || dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
                {
                    MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!int.TryParse(tbPrice.Text, out int price))
                {
                    MessageBox.Show("Неверный формат стоимости!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newSubscription = new Subscription()
                {
                    Price = price,
                    StartDate = dpStartDate.SelectedDate ?? DateTime.Now,
                    EndDate = dpEndDate.SelectedDate ?? DateTime.Now.AddDays(7),
                    SubscriptionTypeID = _subscriptionTypes.FirstOrDefault(x => x.IsChecked == true).Id,
                    UserID = _user.Id
                };

                App.Connection.Subscription.AddOrUpdate(newSubscription);
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
