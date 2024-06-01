using GymKW.Data;
using System.Windows;

namespace GymKW
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static GYMKWEntities Connection = new GYMKWEntities();
    }
}
