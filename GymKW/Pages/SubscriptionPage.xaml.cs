using System.Linq;
using System.Windows.Controls;

namespace GymKW.Pages
{
    /// <summary>
    /// Interaction logic for SubscriptionPage.xaml
    /// </summary>
    public partial class SubscriptionPage : Page
    {
        public SubscriptionPage()
        {
            InitializeComponent();
            var sub = App.Connection.Subscription.OrderByDescending(x => x.Id).FirstOrDefault(x => x.UserID == App.CurrentUser.Id);
            DataContext = sub;
        }
    }
}
