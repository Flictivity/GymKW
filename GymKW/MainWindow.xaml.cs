﻿using GymKW.Pages;
using System.Windows;

namespace GymKW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthorizationPage());
        }
    }
}
