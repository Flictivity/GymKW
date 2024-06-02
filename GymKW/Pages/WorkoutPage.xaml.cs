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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GymKW.Pages
{
    /// <summary>
    /// Interaction logic for WorkoutPage.xaml
    /// </summary>
    public partial class WorkoutPage : Page
    {
        private bool _isVip = false;
        private Workout _workout;
        public WorkoutPage()
        {
            InitializeComponent();

            if(App.CurrentUser == null) {
                return;
            }

            var sub = App.Connection.Subscription.OrderByDescending(x => x.Id).FirstOrDefault(x => x.UserID == App.CurrentUser.Id);

            if ( sub == null){
                return;
            }

            if(sub.SubscriptionTypeID != 3)
            {
                grPersonalCoach.Visibility = Visibility.Collapsed;
            }
            else
            {
                _isVip = true;
                cbCoach.ItemsSource = App.Connection.Coach.ToList();
                if(App.CurrentUser.Coach != null)
                {
                    cbCoach.SelectedItem = App.Connection.Coach.FirstOrDefault(x => x.Id == App.CurrentUser.CoachID);
                }
            }

            _workout = App.Connection.Workout.FirstOrDefault(x => x.Id == App.CurrentUser.WorkoutID);
            DataContext = _workout;
            lvWorkouts.ItemsSource = App.Connection.Workout.ToList();
        }

        private void lvWorkouts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _workout = (Workout)lvWorkouts.SelectedItem;
            DataContext = _workout;
        }

        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = App.Connection.User.FirstOrDefault(x => x.Id == App.CurrentUser.Id);
                user.WorkoutID = _workout.Id;
                if (_isVip)
                {
                    user.CoachID = ((Coach)cbCoach.SelectedItem).Id;
                }

                App.Connection.User.AddOrUpdate(user);
                App.Connection.SaveChanges();
                MessageBox.Show("Успешно!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при сохранении!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
